using Microsoft.EntityFrameworkCore;
using System.Linq;
using YogaCenterLibrary.Models;
using YogaCenterAPIV2.Repositories;
using YogaCenterAPIV2.Utils;
using YogaCenterLibrary.DTO;

namespace YogaCenterAPIV2.DAL
{
    public class ClassRepository : IRepository<Class>
    {
        YogaCenterContext db = new YogaCenterContext();
        SettingRepository settingRepository = new SettingRepository(); 
        public Task Add(Class entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            var classToDelete = await db.Classes.SingleOrDefaultAsync(a => a.Id == id);
            classToDelete.Finished = Constant.Class.FINISHED;
            await db.SaveChangesAsync();
        }

        public Task<List<dynamic>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> GetById(int id)
        {
            var course = await (db.Classes.Where(c => c.Id == id).SingleOrDefaultAsync());;
            return course;
        }

        public Task Update(int id,  Class entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<dynamic>> GetClassByCourseID(int courseID)
        {
            var classes = await (from c in db.Classes
                                 join t in db.Accounts on c.TrainerId equals t.Id
                                 join tt in db.Timetables on c.Id equals tt.ClassId
                                 join s in db.Slots on tt.Id equals s.TimetableId
                                 join tf in db.TimeFrames on s.TimeFrameId equals tf.Id
                                 where c.CourseId == courseID && c.Finished == Constant.Class.UNFINISHED
                                 select new
                                 {
                                     c.Id,
                                     c.ClassName,
                                     c.TrainerId,
                                     c.StartDate,
                                     c.EndDate,
                                     c.Room,
                                     t.Firstname,
                                     t.Lastname,
                                     s.DayOfWeek,
                                     tf.TimeFrame1
                                 }).ToListAsync();

            var result = classes.GroupBy(c => new
            {
                c.Id,
                c.ClassName,
                c.TrainerId,
                c.StartDate,
                c.EndDate,
                c.Room,
                c.Firstname,
                c.Lastname
            }).Select(classGroup => new
            {
                ClassId = classGroup.Key.Id,
                ClassName = classGroup.Key.ClassName,
                TrainerId = classGroup.Key.TrainerId,
                StartDate = classGroup.Key.StartDate,
                EndDate = classGroup.Key.EndDate,
                Room = classGroup.Key.Room,
                Firstname = classGroup.Key.Firstname,
                Lastname = classGroup.Key.Lastname,
                Schedule = classGroup.Select(slot => new { Date = slot.DayOfWeek, Time = slot.TimeFrame1 }).ToList()
            }).ToList();

            return result.Cast<dynamic>().ToList();
        }

        public async Task<dynamic> GetAllClassForAdmin()
        {
            var classes = await (from c in db.Classes
                                 join t in db.Accounts on c.TrainerId equals t.Id
                                 join tt in db.Timetables on c.Id equals tt.ClassId
                                 join s in db.Slots on tt.Id equals s.TimetableId
                                 join tf in db.TimeFrames on s.TimeFrameId equals tf.Id
                                 select new
                                 {
                                     c.Id,
                                     c.ClassName,
                                     c.TrainerId,
                                     c.StartDate,
                                     c.EndDate,
                                     c.Room,
                                     t.Firstname,
                                     t.Lastname,
                                     c.Status,
                                     s.DayOfWeek,
                                     tf.TimeFrame1
                                 }).ToListAsync();

            var classDetails = await (from cd in db.ClassDetails
                                      join c in db.Classes on cd.ClassId equals c.Id
                                      group cd by cd.ClassId into classDetailGroup
                                      select new
                                      {
                                          ClassId = classDetailGroup.Key,
                                          TraineeCount = classDetailGroup.Count()
                                      }).ToListAsync();

            var result = classes.GroupBy(c => new
            {
                c.Id,
                c.ClassName,
                c.TrainerId,
                c.StartDate,
                c.EndDate,
                c.Room,
                c.Firstname,
                c.Lastname,
                c.Status
            }).Select(classGroup => new
            {
                ClassId = classGroup.Key.Id,
                ClassName = classGroup.Key.ClassName,
                TrainerId = classGroup.Key.TrainerId,
                StartDate = classGroup.Key.StartDate,
                EndDate = classGroup.Key.EndDate,
                Room = classGroup.Key.Room,
                NumberTrainee = classDetails.FirstOrDefault(cd => cd.ClassId == classGroup.Key.Id)?.TraineeCount ?? 0,
                Firstname = classGroup.Key.Firstname,
                Lastname = classGroup.Key.Lastname,
                Status = classGroup.Key.Status,
                Schedule = classGroup.Select(slot => new { Date = slot.DayOfWeek, Time = slot.TimeFrame1 }).ToList()
            }).ToList();

            return result.Cast<dynamic>().ToList();
        }

        public async Task<List<dynamic>> GetClassByCourseIDForAdmin(int courseid)
        {
            var classes = await (from c in db.Classes
                                 join t in db.Accounts on c.TrainerId equals t.Id
                                 join tt in db.Timetables on c.Id equals tt.ClassId
                                 join s in db.Slots on tt.Id equals s.TimetableId
                                 join tf in db.TimeFrames on s.TimeFrameId equals tf.Id
                                 where c.CourseId == courseid
                                 select new
                                 {
                                     c.Id,
                                     c.ClassName,
                                     c.TrainerId,
                                     c.StartDate,
                                     c.EndDate,
                                     c.Room,
                                     t.Firstname,
                                     t.Lastname,
                                     c.Status,
                                     s.DayOfWeek,
                                     tf.TimeFrame1
                                 }).ToListAsync();

            var classDetails = await (from cd in db.ClassDetails
                                      join c in db.Classes on cd.ClassId equals c.Id
                                      group cd by cd.ClassId into classDetailGroup
                                      select new
                                      {
                                          ClassId = classDetailGroup.Key,
                                          TraineeCount = classDetailGroup.Count()
                                      }).ToListAsync();

            var result = classes.GroupBy(c => new
            {
                c.Id,
                c.ClassName,
                c.TrainerId,
                c.StartDate,
                c.EndDate,
                c.Room,
                c.Firstname,
                c.Lastname,
                c.Status
            }).Select(classGroup => new
            {
                ClassId = classGroup.Key.Id,
                ClassName = classGroup.Key.ClassName,
                TrainerId = classGroup.Key.TrainerId,
                StartDate = classGroup.Key.StartDate,
                EndDate = classGroup.Key.EndDate,
                Room = classGroup.Key.Room,
                NumberTrainee = classDetails.FirstOrDefault(cd => cd.ClassId == classGroup.Key.Id)?.TraineeCount ?? 0,
                Firstname = classGroup.Key.Firstname,
                Lastname = classGroup.Key.Lastname,
                Status = classGroup.Key.Status,
                Schedule = classGroup.Select(slot => new { Date = slot.DayOfWeek, Time = slot.TimeFrame1 }).ToList()
            }).ToList();

            return result.Cast<dynamic>().ToList();
        }

        public async Task<List<dynamic>> GetClassByCourseIDForAdmin(int courseID, bool finished)
        {
            var classes = await (from c in db.Classes
                                 join t in db.Accounts on c.TrainerId equals t.Id
                                 join tt in db.Timetables on c.Id equals tt.ClassId
                                 join s in db.Slots on tt.Id equals s.TimetableId
                                 join tf in db.TimeFrames on s.TimeFrameId equals tf.Id
                                 where c.CourseId == courseID && c.Finished == finished 
                                        && c.Status != Constant.Class.PENDING
                                 select new
                                 {
                                     c.Id,
                                     c.ClassName,
                                     c.TrainerId,
                                     c.StartDate,
                                     c.EndDate,
                                     c.Room,
                                     t.Firstname,
                                     t.Lastname,
                                     c.Status,
                                     s.DayOfWeek,
                                     tf.TimeFrame1
                                 }).ToListAsync();

            var classDetails = await (from cd in db.ClassDetails
                                      join c in db.Classes on cd.ClassId equals c.Id
                                      where c.CourseId == courseID
                                      group cd by cd.ClassId into classDetailGroup
                                      select new
                                      {
                                          ClassId = classDetailGroup.Key,
                                          TraineeCount = classDetailGroup.Count()
                                      }).ToListAsync();

            var result = classes.GroupBy(c => new
            {
                c.Id,
                c.ClassName,
                c.TrainerId,
                c.StartDate,
                c.EndDate,
                c.Room,
                c.Firstname,
                c.Lastname,
                c.Status
            }).Select(classGroup => new
            {
                ClassId = classGroup.Key.Id,
                ClassName = classGroup.Key.ClassName,
                TrainerId = classGroup.Key.TrainerId,
                StartDate = classGroup.Key.StartDate,
                EndDate = classGroup.Key.EndDate,
                Room = classGroup.Key.Room,
                NumberTrainee = classDetails.FirstOrDefault(cd => cd.ClassId == classGroup.Key.Id)?.TraineeCount ?? 0,
                Firstname = classGroup.Key.Firstname,
                Lastname = classGroup.Key.Lastname,
                Status = classGroup.Key.Status,
                Schedule = classGroup.Select(slot => new { Date = slot.DayOfWeek, Time = slot.TimeFrame1 }).ToList()
            }).ToList();

            return result.Cast<dynamic>().ToList();
        }

        public async Task<List<dynamic>> GetCanceledClassByCourseIDForAdmin(int courseID)
        {
            var classes = await (from c in db.Classes
                                 join t in db.Accounts on c.TrainerId equals t.Id
                                 join tt in db.Timetables on c.Id equals tt.ClassId
                                 join s in db.Slots on tt.Id equals s.TimetableId
                                 join tf in db.TimeFrames on s.TimeFrameId equals tf.Id
                                 where c.CourseId == courseID && c.Finished == Constant.Class.FINISHED
                                        && c.Status == Constant.Class.PENDING
                                 select new
                                 {
                                     c.Id,
                                     c.ClassName,
                                     c.TrainerId,
                                     c.StartDate,
                                     c.EndDate,
                                     c.Room,
                                     t.Firstname,
                                     t.Lastname,
                                     c.Status,
                                     s.DayOfWeek,
                                     tf.TimeFrame1
                                 }).ToListAsync();

            var classDetails = await (from cd in db.ClassDetails
                                      join c in db.Classes on cd.ClassId equals c.Id
                                      where c.CourseId == courseID
                                      group cd by cd.ClassId into classDetailGroup
                                      select new
                                      {
                                          ClassId = classDetailGroup.Key,
                                          TraineeCount = classDetailGroup.Count()
                                      }).ToListAsync();

            var result = classes.GroupBy(c => new
            {
                c.Id,
                c.ClassName,
                c.TrainerId,
                c.StartDate,
                c.EndDate,
                c.Room,
                c.Firstname,
                c.Lastname,
                c.Status
            }).Select(classGroup => new
            {
                ClassId = classGroup.Key.Id,
                ClassName = classGroup.Key.ClassName,
                TrainerId = classGroup.Key.TrainerId,
                StartDate = classGroup.Key.StartDate,
                EndDate = classGroup.Key.EndDate,
                Room = classGroup.Key.Room,
                NumberTrainee = classDetails.FirstOrDefault(cd => cd.ClassId == classGroup.Key.Id)?.TraineeCount ?? 0,
                Firstname = classGroup.Key.Firstname,
                Lastname = classGroup.Key.Lastname,
                Status = classGroup.Key.Status,
                Schedule = classGroup.Select(slot => new { Date = slot.DayOfWeek, Time = slot.TimeFrame1 }).ToList()
            }).ToList();

            return result.Cast<dynamic>().ToList();
        }

        public async Task<List<dynamic>> GetClassesOfRoom(string room)
        {

            var classes = await (from cl in db.Classes
                                  join c in db.Courses on cl.CourseId equals c.Id
                                  join tt in db.Timetables on cl.Id equals tt.ClassId
                                  join s in db.Slots on tt.Id equals s.TimetableId
                                  join t in db.Accounts on cl.TrainerId equals t.Id
                                  where cl.Room == room && cl.Finished == Constant.Class.UNFINISHED
                                  select new
                                  {
                                      id = cl.Id,
                                      className = cl.ClassName,
                                      trainerId = cl.TrainerId,
                                      courseId = cl.CourseId,
                                      room = room,
                                      startDate = cl.StartDate,
                                      endDate = cl.EndDate,
                                      isFinished = cl.Finished,
                                      courseName = c.CourseName,
                                      firstName = t.Firstname,
                                      lastName = t.Lastname,
                                      day = s.DayOfWeek,
                                      timeFrame = s.TimeFrame
                                  }).ToListAsync();

            var result = classes.GroupBy(c => new
            {
                c.id,
                c.className,
                c.trainerId,
                c.courseId,
                c.room,
                c.startDate,
                c.endDate,
                c.isFinished,
                c.courseName,
                c.firstName,
                c.lastName
            }).Select(classGroup => new
            {
                id = classGroup.Key.id,
                className = classGroup.Key.className,
                trainerId = classGroup.Key.trainerId,
                courseId = classGroup.Key.courseId,
                room = classGroup.Key.room,
                startDate = classGroup.Key.startDate,
                endDate = classGroup.Key.endDate,
                isFinished = classGroup.Key.isFinished,
                courseName = classGroup.Key.courseName,
                firstName = classGroup.Key.firstName,
                lastName = classGroup.Key.lastName,
                Schedule = classGroup.Select(slot => new { Date = slot.day, timeframeId = slot.timeFrame.Id, timeFrame = slot.timeFrame.TimeFrame1 }).ToList()
            }).ToList();
            return result.Cast<dynamic>().ToList();
        }
       
        public async Task<dynamic> CreateClass( CreateClassRequest request)
        {
            db.Classes.Add(request.ClassDTO);
            await db.SaveChangesAsync();
            Timetable timetable = new Timetable();
            timetable.ClassId = request.ClassDTO.Id;
            db.Timetables.Add(timetable);
            await db.SaveChangesAsync();

            foreach (var slotDTO in request.SlotDTOs)
            {
                slotDTO.TimetableId = timetable.Id;
                db.Slots.Add(slotDTO);
            }

            await db.SaveChangesAsync();

            return request.ClassDTO.Id;
        }

        public async Task<int> GetTimetableId(int classId)
        {
            var timetable = await db.Timetables.FirstOrDefaultAsync(t => t.ClassId == classId);
            if (timetable != null)
            {
                return timetable.Id;
            }
            return 0;
        }

        public async Task<List<dynamic>> getTraineeInClass(int traineeId)
        {
            var traineeLearning = await (from cl in db.Classes
                                         join cd in db.ClassDetails on cl.Id equals cd.ClassId
                                         where cd.TraineeId == traineeId && cl.Finished == Constant.Class.UNFINISHED
                                         select cl.Id).ToListAsync();
            return traineeLearning.Cast<dynamic>().ToList();
        }

        public async Task<dynamic> getClassofTraineeQuanity(int traineeId)
        {
           var num =  await db.ClassDetails.Where(cd => cd.TraineeId == traineeId).CountAsync();
            return num;
        }

     
    }
}
