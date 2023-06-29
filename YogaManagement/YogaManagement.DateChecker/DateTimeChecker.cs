using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaManagement.Business.Repositories;
using YogaManagement.Domain.Enums;
using YogaManagement.Domain.Models;

namespace YogaManagement.DateChecker;
public class DateTimeChecker
{
    private readonly CourseRepository _courseRepo;
    private readonly YogaClassRepository _ygClassRepo;
    private readonly EnrollmentRepository _enrollmentRepo;
    private readonly WalletRepository _walletRepo;
    private readonly TransactionRepository _transacRepo;
    private readonly TeacherEnrollmentRepository _tcErRepo;
    private readonly TeacherScheduleRepository _tcScheduleRepo;
    private readonly ScheduleRepository _scheduleRepo;

    public DateTimeChecker(CourseRepository courseRepo,
        YogaClassRepository ygClassRepo,
        EnrollmentRepository enrollmentRepo,
        WalletRepository walletRepo,
        TransactionRepository transacRepo,
        TeacherEnrollmentRepository tcErRepo,
        TeacherScheduleRepository tcScheduleRepo,
        ScheduleRepository scheduleRepo)
    {
        _courseRepo = courseRepo;
        _ygClassRepo = ygClassRepo;
        _enrollmentRepo = enrollmentRepo;
        _walletRepo = walletRepo;
        _transacRepo = transacRepo;
        _tcErRepo = tcErRepo;
        _tcScheduleRepo = tcScheduleRepo;
        _scheduleRepo = scheduleRepo;
    }

    // End course will be delete and all active class become finish
    public async Task UpdateFinishCourseClassAsync()
    {
        Console.WriteLine("Update finish courses ...");
        var courses = _courseRepo.GetAll()
            .Include(x => x.YogaClasses)
            .Where(x => x.IsActive &&
                x.EnddDate < DateTime.Now)
            .ToList();

        foreach (var course in courses)
        {
            course.IsActive = false;
            var activeClass = course.YogaClasses
                .Where(x => x.YogaClassStatus == YogaClassStatus.Active)
                .ToList();
            foreach (var yogaClass in activeClass)
            {
                yogaClass.YogaClassStatus = YogaClassStatus.Finish;
                await _ygClassRepo.UpdateAsync(yogaClass);
            }
            await _courseRepo.UpdateAsync(course);
        }
    }


    // Ongoing course, all pending class delete and refund to member. 
    public async Task UpdateOngoingCourseClass()
    {
        Console.WriteLine("Update start course ...");
        // Find started courses
        var courses = _courseRepo.GetAll()
            .Include(x => x.YogaClasses)
            .Where(x => x.IsActive &&
                x.StartDate < DateTime.Now &&
                x.EnddDate > DateTime.Now)
            .ToList();

        var adminWallet = _walletRepo.GetAll()
                .SingleOrDefault(x => x.IsAdminWallet);

        foreach (var course in courses)
        {
            // find pending class in started courses
            var pendingClass = course.YogaClasses
                .Where(x => x.YogaClassStatus == YogaClassStatus.Pending)
                .ToList();

            foreach (var yogaClass in pendingClass)
            {
                #region DeleteTeacherEnrollemt
                var existEnrolls = _tcErRepo.GetAll()
                    .Where(x => x.YogaClassId == yogaClass.Id)
                    .ToList();
                foreach (var existEnroll in existEnrolls)
                {
                    try
                    {
                        var tcSchedule = _tcScheduleRepo.GetAll()
                            .Include(x => x.TimeSlot)
                            .Where(x => x.TeacherProfileId == existEnroll.TeacherProfileId
                                && !x.IsTaken)
                            .ToList();

                        var classSchedule = _scheduleRepo.GetAll()
                            .Include(x => x.TimeSlot)
                            .Where(x => x.YogaClassId == existEnroll.YogaClassId)
                            .ToList().Select(x => x.TimeSlotId);

                        existEnroll.IsActive = false;
                        await _tcErRepo.UpdateAsync(existEnroll);

                        foreach (var timeSlot in classSchedule)
                        {
                            var teacherTimeSlot = tcSchedule
                                .SingleOrDefault(x => x.TimeSlotId == timeSlot);
                            teacherTimeSlot.IsTaken = false;
                            await _tcScheduleRepo.UpdateAsync(teacherTimeSlot);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                #endregion

                #region DeleteAndRefundMemberEnrollemt
                // find member who enroll in class
                var enrollments = _enrollmentRepo.GetAll()
                    .Include(x => x.Member)
                    .ThenInclude(x => x.AppUser)
                    .ThenInclude(x => x.Wallet)
                    .Where(x => x.YogaClassId == yogaClass.Id)
                    .ToList();
                try
                {
                    foreach (var enrollment in enrollments)
                    {
                        var wallet = enrollment.Member.AppUser.Wallet;
                        double transacAmount = course.Price * (1 - enrollment.Discount);
                        // refund
                        if (adminWallet.Balance >= transacAmount)
                        {
                            wallet.Balance += transacAmount;
                            adminWallet.Balance -= transacAmount;
                            await _transacRepo.CreateAsync(new Transaction
                            {
                                Amount = transacAmount,
                                Content = $"Refund for course {course.Name}",
                                CreatedDate = DateTime.Today,
                                TransactionType = TransactionType.Refund,
                                WalletId = wallet.Id
                            });
                            await _walletRepo.UpdateAsync(adminWallet);
                            await _walletRepo.UpdateAsync(wallet);
                            await _enrollmentRepo.DeleteAsync(enrollment);
                        }
                        else
                        {
                            throw new Exception("Refund not available now");
                        }
                    }
                    yogaClass.YogaClassStatus = YogaClassStatus.Inactive;
                    await _ygClassRepo.UpdateAsync(yogaClass);
                }
                catch { }
            }
            #endregion
        }
    }
}
