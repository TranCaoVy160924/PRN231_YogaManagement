using Microsoft.EntityFrameworkCore;
using Nancy.Extensions;
using Nancy.ViewEngines;
using Org.BouncyCastle.Utilities;
using YogaCenterLibrary.Models;
using YogaCenterAPIV2.Repositories;
using YogaCenterAPIV2.Utils;
using YogaCenterLibrary.DTO;
using System.Runtime.InteropServices;

namespace YogaCenterAPIV2.DAL
{
    public class BookingRepository : IRepository<Booking>
    {
        SettingRepository settingRepository = new SettingRepository();
        YogaCenterContext db = new YogaCenterContext();
        TraineeRepository traineeRepository = new TraineeRepository();
        public BookingRepository() { }
        public async Task Add(Booking entity)
        {

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "The booking entity cannot be null.");
            }
            DateTime date = Util.getInstance().GetCurrentDateTimeInTimeZone();

            var course = await db.Courses.SingleOrDefaultAsync(c => c.Id == entity.CourseId);
            var classdto = await db.Classes.SingleOrDefaultAsync(c => c.Id == entity.ClassId);

            if (course != null && classdto != null)
            {
                entity.BookingDate = date;
                entity.PayDate = null;
                entity.RefundDate = null;
                entity.PaymentTransactionId = null;
                if (entity.Status != Constant.Booking.RESERVED && entity.Status != Constant.Booking.PENDING_PAY && entity.Status != Constant.Booking.SUCCESS_ATM)
                {
                    throw new Exception("You must choice the status reserved (5) , pending (0), success with atm (7) ");
                }
                //    entity.Status = Constant.Booking.PENDING_PAY;
                entity.Amount = (double)(course.Price * (100 - course.Discount) / 100);
                if (entity.Status == Constant.Booking.SUCCESS_ATM)
                {
                    entity.PayDate = date;
                }
                db.Bookings.Add(entity);
                await db.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Course with ID {entity.CourseId} does not exist.");
            }
        }



        public async Task Delete(int id)
        {
            var booking = await db.Bookings.FindAsync(id);
            if (booking != null)
            {
                db.Remove(booking);
            }
            await db.SaveChangesAsync();

        }

        public async Task<List<dynamic>> GetAll()
        {
            var bookingList = await (from b in db.Bookings
                                     join c in db.Courses
                                     on b.CourseId equals c.Id
                                     join a in db.Accounts
                                     on b.AccountId equals a.Id
                                     join cl in db.Classes
                                     on b.ClassId equals cl.Id
                                     select new
                                     {
                                         ID = b.Id,
                                         Amount = b.Amount,
                                         Status = b.Status,
                                         BookingDate = b.BookingDate,
                                         PayDate = b.PayDate,
                                         RefundDate = b.RefundDate,
                                         Account = new
                                         {
                                             AccountID = a.Id,
                                             FirstName = a.Firstname,
                                             LastName = a.Lastname,
                                             Phone = a.PhoneNumber
                                         },
                                         Course = new
                                         {
                                             CourseID = c.Id,
                                             CourseName = c.CourseName
                                         },
                                         Class = new
                                         {
                                             ClassID = cl.Id,
                                             ClassName = cl.ClassName,
                                         }

                                     }).ToListAsync();
            if (bookingList.Count == 0 || bookingList == null)
            {
                return null;
            }
            return bookingList.Cast<dynamic>().ToList(); ;
        }

        public async Task<dynamic> GetById(int id)
        {
            var booking = await db.Bookings.FirstOrDefaultAsync(b => b.Id == id);

            return booking;
        }
        public async Task<dynamic> GetByAccountIdAndCourseId(int accId, int courseId)
        {
            var booking = await db.Bookings.FirstOrDefaultAsync(b => b.AccountId == accId && b.CourseId == courseId);
            if (booking != null)
            {
                return booking;
            }
            return null;
        }
        public async Task<dynamic> GetByAccountId(int accId)
        {
            var bookings = await db.Bookings
                .Where(b => b.AccountId == accId)            
                .ToListAsync();

            if (bookings != null)
            {
                return bookings;
            }

            return null;
        }

        public Task Update(int id, Booking entity)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> UpdateStatus(int bookingId, int status)
        {
            var booking = await db.Bookings.FirstOrDefaultAsync(b => b.Id == status);
            if (booking != null)
            {
                booking.Status = status;
                await db.SaveChangesAsync();
                return status;
            }

            return null;
        }

        public async Task<double> GetBookingRemainTime(int traineeId)
        {
            var traineeBooking = await db.Bookings.FirstOrDefaultAsync(b => b.AccountId == traineeId && b.Status == Constant.Booking.RESERVED);


            if (traineeBooking != null)
            {
                if (traineeBooking.BookingDate != null)
                {
                    long timePassedInTick = Util.getInstance().GetCurrentDateTimeInTimeZone().Ticks - traineeBooking.BookingDate.Value.Ticks;
                    double remain = (double)(await settingRepository.getSettingValue(1) * 60 - timePassedInTick / TimeSpan.TicksPerMinute);
                    return remain;
                }
            }
            return double.MaxValue;
        }

        public async Task<double> GetRefundRemainTime(int traineeId)
        {
            var traineeBooking = await db.Bookings.FirstOrDefaultAsync(b => b.AccountId == traineeId && b.Status == Constant.Booking.SUCCESS_PAY);
            if (traineeBooking.PayDate != null)
            {
                long timePassedInTick = Util.getInstance().GetCurrentDateTimeInTimeZone().Ticks - traineeBooking.PayDate.Value.Ticks;
                double remain = (double)(await settingRepository.getSettingValue(2) * 60 - timePassedInTick / TimeSpan.TicksPerMinute);
                return remain;
            }
            return double.MaxValue;
        }

        public async Task UpdateBooking(Booking booking)
        {
            var oldBooking = await db.Bookings.FirstOrDefaultAsync(b => b.AccountId == booking.AccountId
                                                                     && b.ClassId == booking.ClassId
                                                                     && b.CourseId == booking.CourseId);
            if (oldBooking != null)
            {
                oldBooking.PayDate = Util.getInstance().GetCurrentDateTimeInTimeZone();
                oldBooking.Status = booking.Status;
                if (booking.Status == Constant.Booking.SUCCESS_PAY)
                {
                    var checkClass = await (db.ClassDetails.Where(c => c.TraineeId == booking.AccountId).SingleOrDefaultAsync());
                    if (checkClass == null)
                    {
                        var classdetail = new ClassDetail { ClassId = booking.ClassId, TraineeId = booking.AccountId };
                        db.ClassDetails.Add(classdetail);
                    }
                }
                await db.SaveChangesAsync();
            }
        }

        public async Task<dynamic> getBookingWithStatus(int traineeId, int status)
        {
            var booking = await db.Bookings.Where(b => b.AccountId == traineeId
                                            && b.Status == status).FirstOrDefaultAsync();
            return booking;
        }

        public async Task<dynamic> getCourseRevenueReport(int courseId, int year)
        {
            //Revenue based on booking

            var annualRevenue = await (from b in db.Bookings
                                       where b.CourseId == courseId
                                       && b.PayDate.Value.Year == year
                                       && b.Status == Constant.Booking.FAIL_REFUND
                                       select b.Amount).SumAsync();
            //Number of class, excluding those that has or hadn't been activated
            var annualNumberOfClass = await (from cl in db.Classes
                                             where cl.CourseId == courseId
                                             && cl.StartDate.Value.Year == year
                                             && cl.Status != Constant.Class.PENDING
                                             select cl.Id).CountAsync();
            // Number of trainee, excluding those whose classes haven't or hadn't been activated
            var annualNumberOfTrainee = await (from cl in db.Classes
                                               join cd in db.ClassDetails on cl.Id equals cd.ClassId
                                               where cl.CourseId == courseId
                                               && cl.StartDate.Value.Year == year
                                               && cl.Status != Constant.Class.PENDING
                                               select cd.Id).CountAsync();
            List<MonthlyReport> months = new List<MonthlyReport>();
            for (int i = 1; i <= 12; i++)
            {
                var classOfMonth = await (from cl in db.Classes
                                          where cl.CourseId == courseId
                                          && cl.StartDate.Value.Year == year
                                          && cl.StartDate.Value.Month <= i
                                          && cl.EndDate.Value.Year == year
                                          && cl.EndDate.Value.Month >= i
                                           && cl.Status != Constant.Class.PENDING
                                          select cl.Id).CountAsync();


                var traineeOfMonth = await (from cl in db.Classes
                                            join cd in db.ClassDetails on cl.Id equals cd.ClassId
                                            where cl.CourseId == courseId
                                          && cl.StartDate.Value.Year == year
                                          && cl.StartDate.Value.Month <= i
                                          && cl.EndDate.Value.Year == year
                                          && cl.EndDate.Value.Month >= i
                                           && cl.Status != Constant.Class.PENDING
                                            select cd.Id).CountAsync();

                var revenueOfMonth = await (from b in db.Bookings
                                            where b.CourseId == courseId
                                            && b.PayDate.Value.Month == i
                                            && b.PayDate.Value.Year == year
                                            && b.Status == Constant.Booking.FAIL_REFUND
                                            select b.Amount).SumAsync();

                if (revenueOfMonth == null)
                {
                    revenueOfMonth = 0;
                }

                months.Add(new MonthlyReport(i, classOfMonth, traineeOfMonth, revenueOfMonth));
            }
            CourseReport courseReport = new CourseReport();
            courseReport.annualRevenue = (double)annualRevenue;
            courseReport.numOfTrainee = annualNumberOfTrainee;
            courseReport.numOfClass = annualNumberOfClass;
            courseReport.monthlyReports = months;
            return courseReport;
        }

        public async Task<dynamic> updateStatus(int id, int status)
        {
            var booking = await db.Bookings.FindAsync(id);
            if (booking == null)
            {
                throw new Exception("The booking isn't exist");
            }
            booking.Status = status;

            if(status == Constant.Booking.SUCCESS_ATM)
            {
                DateTime date = Util.getInstance().GetCurrentDateTimeInTimeZone();

                booking.PayDate = date;
            }

            await db.SaveChangesAsync();
            return booking;
        }

        public async Task<List<dynamic>> getBookingListByStatus(int status)
        {
            var bookingList = await db.Bookings.Where(b => b.Status == status).ToListAsync();
            return bookingList.Cast<dynamic>().ToList();
        }

       

    }
}
