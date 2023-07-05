using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using YogaCenterLibrary.Models;
using YogaCenterAPIV2.Utils;
using Constant = YogaCenterAPIV2.Utils.Constant;

namespace YogaCenterAPIV2.DAL
{
    public class TrainerRepository
    {
        YogaCenterContext db = new YogaCenterContext();
        public TrainerRepository() {}

        public async Task<List<dynamic>> GetClassList(int trainerId)
        {
            var classList = await (from cl in db.Classes
                                   join c in db.Courses on cl.CourseId equals c.Id
                                   where cl.TrainerId == trainerId
                                   select new
                                   {
                                       classID = c.Id,
                                       courseName = c.CourseName,
                                       ClassName = cl.ClassName,
                                       startDate = cl.StartDate,
                                       endDate = cl.EndDate
                                   }).ToListAsync();
            return classList.Cast<dynamic>().ToList();
        }

        public async Task<List<dynamic>> GetTraineesListOfClass(int classId)
        {
            var traineeList = await (from cl in db.Classes
                                     join cd in db.ClassDetails on cl.Id equals cd.ClassId
                                     join a in db.Accounts on cd.TraineeId equals a.Id
                                     where cl.Id == classId
                                     select new
                                     {
                                         id = a.Id,
                                         firstName = a.Firstname,
                                         lastName = a.Lastname,
                                         gender = a.Gender,
                                         phone = a.PhoneNumber,
                                         img = a.Img
                                     }
                                     ).ToListAsync();
            return traineeList.Cast<dynamic>().ToList();
        }

        public async Task<List<dynamic>> GetSlotList(int trainerId)
        {
            var slotList = await (from cl in db.Classes
                                  join ttb in db.Timetables on cl.Id equals ttb.ClassId
                                  join c in db.Courses on cl.CourseId equals c.Id
                                  join s in db.Slots on ttb.Id equals s.TimetableId
                                  join tf in db.TimeFrames on s.TimeFrameId equals tf.Id
                                  where cl.TrainerId == trainerId
                                  select new
                                  {
                                      slotID = s.Id,
                                      courseName = c.CourseName,
                                      room = cl.Room,
                                      timeframe = tf.TimeFrame1
                                  }
                                 ).ToListAsync();
            return slotList.Cast<dynamic>().ToList();
        }

        public async Task<List<dynamic>> getListClassForTrainer(int id)
        {
            var classes = await (from cl in db.Classes 
                                 join t in db.Timetables on cl.Id equals t.ClassId
                                 join s in db.Slots on t.Id equals s.TimetableId
                                 join c in db.Courses on cl.CourseId equals c.Id
                                 join a in db.Accounts on cl.TrainerId equals a.Id
                                 where cl.TrainerId == id
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
            return result.Cast<dynamic>().ToList();
        }

        public async Task<List<dynamic>> getCurrentListClassForTrainer(int id)
        {
            var classes = await (from cl in db.Classes
                                 join t in db.Timetables on cl.Id equals t.ClassId
                                 join s in db.Slots on t.Id equals s.TimetableId
                                 join c in db.Courses on cl.CourseId equals c.Id
                                 join a in db.Accounts on cl.TrainerId equals a.Id
                                 where cl.TrainerId == id && cl.Finished == Constant.Class.UNFINISHED
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
            return result.Cast<dynamic>().ToList();
        }
    }
}
