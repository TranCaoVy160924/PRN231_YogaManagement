using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using YogaManagement.Application.Utilities;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.YogaClass;
using YogaManagement.Domain.Enums;
using YogaManagement.Domain.Models;

namespace YogaManagement.Application.Controllers;
public class YogaClassesController : ODataController
{
    private readonly IMapper _mapper;
    private readonly YogaClassRepository _ygClassRepo;
    private readonly EnrollmentRepository _enrollmentRepo;
    private readonly WalletRepository _walletRepo;
    private readonly TransactionRepository _transacRepo;
    private readonly CourseRepository _courseRepo;
    private readonly ScheduleRepository _scheduleRepo;
    private readonly TeacherEnrollmentRepository _tcEnrollRepo; 

    public YogaClassesController(YogaClassRepository yogaClassRepository,
        EnrollmentRepository enrollmentRepo,
        WalletRepository walletRepo,
        TransactionRepository transacRepo,
        CourseRepository courseRepo,
        TeacherEnrollmentRepository tcEnrollRepo,
        ScheduleRepository scheduleRepo,
        IMapper mapper)
    {
        _mapper = mapper;
        _enrollmentRepo = enrollmentRepo;
        _walletRepo = walletRepo;
        _transacRepo = transacRepo;
        _ygClassRepo = yogaClassRepository;
        _courseRepo = courseRepo;
        _tcEnrollRepo = tcEnrollRepo;
        _scheduleRepo = scheduleRepo;
    }

    [EnableQuery]
    [Authorize]
    public ActionResult<IQueryable<YogaClassDTO>> Get()
    {
        return Ok(_mapper.ProjectTo<YogaClassDTO>(_ygClassRepo.GetAll()));
    }

    [EnableQuery]
    [Authorize]
    public async Task<ActionResult<YogaClassDTO>> Get([FromRoute] int key)
    {
        var ygClass = await _ygClassRepo.Get(key);

        if (ygClass == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<YogaClassDTO>(ygClass));
    }

    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Post([FromBody] YogaClassDTO createRequest)
    {
        try
        {
            ModelState.Remove("CourseName");
            ModelState.ValidateRequest();

            Course course = await _courseRepo.Get(createRequest.CourseId);
            if (!course.IsActive)
            {
                throw new Exception("Course is inactive");
            }
            if (course.StartDate < DateTime.Today && course.EnddDate > DateTime.Today)
            {
                throw new Exception("Course already started");
            }
            if (course.EnddDate < DateTime.Today)
            {
                throw new Exception("Course already ended");
            }

            var newYgClass = _mapper.Map<YogaClass>(createRequest);
            newYgClass.YogaClassStatus = YogaClassStatus.Pending;
            await _ygClassRepo.CreateAsync(newYgClass);
            return Created(createRequest);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Patch([FromRoute] int key, [FromBody] Delta<YogaClassDTO> delta)
    {
        var existClass = _ygClassRepo.GetAll()
            .Include(x => x.Enrollments)
            .SingleOrDefault(x => x.Id == key);
        var update = delta.GetInstance();

        var existTcEnroll = await _tcEnrollRepo.GetAll()
            .Where(x => x.YogaClassId == key
                && x.IsActive)
            .ToListAsync();

        var classSchedule = await _scheduleRepo.GetAll()
            .Where(x => x.YogaClassId == key)
            .ToListAsync();

        try
        {
            if (existClass.YogaClassStatus != YogaClassStatus.Pending)
            {
                throw new Exception("Invalid class activation request");
            }

            if (existClass.Enrollments.Count() < 5)
            {
                throw new Exception("Not enough enrollment for activation");
            }

            if (existTcEnroll.Count == 0)
            {
                throw new Exception("Class do not have teacher enrolled! Cannot be activate");
            }

            if (classSchedule.Count == 0)
            {
                throw new Exception("Class do not have schedule! Cannot be activate");
            }

            existClass.YogaClassStatus = YogaClassStatus.Active;
            await _ygClassRepo.UpdateAsync(existClass);
            return Updated(update);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize(Roles = "Staff")]
    [HttpDelete]
    public async Task<IActionResult> Delete(int key)
    {
        var existClass = await _ygClassRepo.Get(key);
        var course = existClass.Course;
        var adminWallet = _walletRepo.GetAll()
            .SingleOrDefault(x => x.IsAdminWallet);
        if (existClass == null)
        {
            return NotFound();
        }

        try
        {
            if (existClass.YogaClassStatus != YogaClassStatus.Pending)
            {
                throw new Exception("Only pending class can be delete");
            }

            // find member who enroll in class
            var enrollments = _enrollmentRepo.GetAll()
                .Include(x => x.Member)
                .ThenInclude(x => x.AppUser)
                .ThenInclude(x => x.Wallet)
                .Where(x => x.YogaClassId == existClass.Id)
                .ToList();


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

            existClass.YogaClassStatus = YogaClassStatus.Inactive;
            await _ygClassRepo.UpdateAsync(existClass);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
