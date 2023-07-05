using Microsoft.EntityFrameworkCore;
using YogaCenterLibrary.Models;
using YogaCenterAPIV2.Utils;
using YogaCenterAPIV2.Repositories;
using static YogaCenterAPIV2.Utils.Constant;
using Microsoft.Identity.Client;

namespace YogaCenterAPIV2.DAL
{
    public class TraineeRepository 
    {
        YogaCenterContext db = new YogaCenterContext();
        public TraineeRepository() { }
        public async Task<List<dynamic>> getAllInformation()
        {
            var accountList = await (from cl in db.ClassDetails
                                     join a in db.Accounts 
                                     on cl.TraineeId equals a.Id
                                     join c in db.Classes
                                     on cl.ClassId equals c.Id
                                     join course in db.Courses
                                     on c.CourseId equals course.Id
                                     join lv in db.Levels
                                     on course.LevelId equals lv.Id
                                     where a.RoleId == Constant.Role.TRAINEE_ROLEID
                                     && c.Finished == Constant.Class.UNFINISHED
                                     select new
                                     {
                                         AccountID = a.Id,
                                         Email = a.Email,
                                         FirstName = a.Firstname,
                                         LastName = a.Lastname,
                                         PhoneNumber = a.PhoneNumber,
                                         Address = a.Address,
                                         RecoveryCode = a.ValidationCode,
                                         Img = a.Img,
                                         Gender = a.Gender,
                                         Deleted = a.Deleted,
                                         Role = new { Id = a.Role.Id, Name = a.Role.Name },
                                         CourseName = course.CourseName,
                                         ClassName = c.ClassName,
                                         Level = lv.LevelName
                                     }).ToListAsync();
            return accountList.Cast<dynamic>().ToList();
        }
        public async Task<List<dynamic>> GetTraineeCourses(int traineeId)
        {
            var courseList = await (from c in db.Courses
                                    join l in db.Levels on c.LevelId equals l.Id
                                    join cl in db.Classes on c.Id equals cl.CourseId
                                    join cd in db.ClassDetails on cl.Id equals cd.ClassId
                                    where cd.TraineeId == traineeId
                                    select new
                                    {
                                        id = c.Id,
                                        CourseName = c.CourseName,
                                        ClassName = cl.ClassName,
                                        Price = c.Price,
                                        LevelId = c.LevelId,
                                        LevelName = l.LevelName,
                                        Description = c.Description,
                                        Img = c.Img
                                    }).ToListAsync();
            return courseList.Cast<dynamic>().ToList();
        }

        public async Task<dynamic> AddToClass(int TraineeId, int ClassId)
        {
            var classdetail = new ClassDetail { ClassId = ClassId, TraineeId = TraineeId};
            db.ClassDetails.Add(classdetail);
            await db.SaveChangesAsync();
            return null;
        }

        public async Task<dynamic> removeTraineeFromClass(int traineeId, int classId)
        {
            var classdetail = await db.ClassDetails.Where(cd => cd.ClassId == classId && cd.TraineeId == traineeId).FirstOrDefaultAsync();

            if (classdetail != null)
            {
                db.ClassDetails.Remove(classdetail);
                await db.SaveChangesAsync();
            }

            return null;
        }

        public async Task<int> CountTraineeClass(int id)
        {
            var num = await db.ClassDetails.Where(cl => cl.ClassId == id).CountAsync();
            return num;
            
        }

        public async Task<List<dynamic>> getListClassForTrainee(int id)
        {
                var classes = await (from cd in db.ClassDetails
                                     join cl in db.Classes on cd.ClassId equals cl.Id
                                     join t in db.Timetables on cl.Id equals t.ClassId
                                     join s in db.Slots on t.Id equals s.TimetableId
                                     join c in db.Courses on cl.CourseId equals c.Id
                                     join a in db.Accounts on cl.TrainerId equals a.Id
                                     where cd.TraineeId == id
                                     select new
                                     {
                                         courseId = c.Id,
                                         courseName = c.CourseName,
                                         courseImg = c.Img,
                                         level = c.Level,
                                         classId = cl.Id,
                                         classname = cl.ClassName,
                                         room = cl.Room,
                                         startDate = cl.StartDate,
                                         endDate = cl.EndDate,
                                         trainerId = cl.TrainerId,
                                         firstName = a.Firstname,
                                         lastName = a.Lastname,
                                         img = a.Img,
                                         phone = a.PhoneNumber,
                                         day = s.DayOfWeek,
                                         timeFrame = s.TimeFrame
                                         }).ToListAsync();

                var result = classes.GroupBy(c => new
                {
                    c.courseId,
                    c.courseName,
                    c.courseImg,
                    c.level,
                    c.classId,
                    c.classname,
                    c.room,
                    c.startDate,
                    c.endDate,
                    c.trainerId,
                    c.firstName,
                    c.lastName,
                    c.img,
                    c.phone
                }).Select(classGroup => new
                {
                    courseId = classGroup.Key.courseId,
                    courseName = classGroup.Key.courseName,
                    courseImg = classGroup.Key.courseImg,
                    level = classGroup.Key.level,
                    classId = classGroup.Key.classId,
                    className = classGroup.Key.classname,
                    room = classGroup.Key.room,
                    startDate = classGroup.Key.startDate,
                    endDate = classGroup.Key.endDate,
                    trainerId = classGroup.Key.trainerId,
                    firstName = classGroup.Key.firstName,
                    lastName = classGroup.Key.lastName,
                    img = classGroup.Key.img,
                    phone = classGroup.Key.phone,
                    Schedule = classGroup.Select(slot => new { Date = slot.day, timeframeId = slot.timeFrame.Id, timeFrame = slot.timeFrame.TimeFrame1 }).ToList()
                }).ToList();
                return result.Cast<dynamic>().ToList(); ;
            }

        public async Task<List<dynamic>> getCurrentListClassForTrainee(int id)
        {
            var classes = await (from cd in db.ClassDetails
                                 join cl in db.Classes on cd.ClassId equals cl.Id
                                 join t in db.Timetables on cl.Id equals t.ClassId
                                 join s in db.Slots on t.Id equals s.TimetableId
                                 join c in db.Courses on cl.CourseId equals c.Id
                                 join a in db.Accounts on cl.TrainerId equals a.Id
                                 where cd.TraineeId == id && cl.Finished == Constant.Class.UNFINISHED
                                 select new
                                 {
                                     courseId = c.Id,
                                     courseName = c.CourseName,
                                     courseImg = c.Img,
                                     level = c.Level,
                                     classId = cl.Id,
                                     classname = cl.ClassName,
                                     room = cl.Room,
                                     startDate = cl.StartDate,
                                     endDate = cl.EndDate,
                                     trainerId = cl.TrainerId,
                                     firstName = a.Firstname,
                                     lastName = a.Lastname,
                                     img = a.Img,
                                     phone = a.PhoneNumber,
                                     day = s.DayOfWeek,
                                     timeFrame = s.TimeFrame
                                 }).ToListAsync();

            var result = classes.GroupBy(c => new
            {
                c.courseId,
                c.courseName,
                c.courseImg,
                c.level,
                c.classId,
                c.classname,
                c.room,
                c.startDate,
                c.endDate,
                c.trainerId,
                c.firstName,
                c.lastName,
                c.img,
                c.phone
            }).Select(classGroup => new
            {
                courseId = classGroup.Key.courseId,
                courseName = classGroup.Key.courseName,
                courseImg = classGroup.Key.courseImg,
                level = classGroup.Key.level,
                classId = classGroup.Key.classId,
                className = classGroup.Key.classname,
                room = classGroup.Key.room,
                startDate = classGroup.Key.startDate,
                endDate = classGroup.Key.endDate,
                trainerId = classGroup.Key.trainerId,
                firstName = classGroup.Key.firstName,
                lastName = classGroup.Key.lastName,
                img = classGroup.Key.img,
                phone = classGroup.Key.phone,
                Schedule = classGroup.Select(slot => new { Date = slot.day, timeframeId = slot.timeFrame.Id, timeFrame = slot.timeFrame.TimeFrame1 }).ToList()
            }).ToList();
            return result.Cast<dynamic>().ToList(); ;
        }

    }
    }

