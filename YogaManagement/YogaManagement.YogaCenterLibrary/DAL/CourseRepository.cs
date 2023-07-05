using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using YogaCenterLibrary.Models;
using YogaCenterAPIV2.Repositories;

namespace YogaCenterAPIV2.DAL
{
    public class CourseRepository : IRepository<Course>
    {
        YogaCenterContext db = new YogaCenterContext();
        public CourseRepository() { }
        public async Task Add(Course course)
        {
            var newCourse = new Course {CourseName= course.CourseName,Price= course.Price,Discount= course.Discount,LevelId= course.LevelId, Description= course.Description,Img= course.Img,Deleted= course.Deleted };
            db.Courses.Add(newCourse);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var course = await(db.Courses.Where(c => c.Id == id)).SingleOrDefaultAsync();
            if (course != null)
            {
                course.Deleted = true;
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<dynamic>> GetAll()
        {
            var courseList = await(from c in db.Courses
                               select new
                               {
                                   CourseID = c.Id,
                                   CourseName = c.CourseName,
                                   Price = c.Price,
                                   Discount = c.Discount,

                                   LevelId = c.LevelId,
                                   LevelName = c.Level.LevelName,
                                   Description = c.Description,
                                   CourseImg = c.Img,
                                   Deleted = c.Deleted
                               }).ToListAsync();
            return courseList.Cast<dynamic>().ToList();

        }

        public async Task<dynamic> GetById(int id)
        {
            var course = await (from c in db.Courses
                               where c.Id == id
                               select new
                               {
                                   CourseID = c.Id,
                                   CourseName = c.CourseName,
                                   Price = c.Price,
                                   Discount = c.Discount,
                                   LevelId = c.LevelId,
                                   LevelName = c.Level.LevelName,
                                   Description = c.Description,
                                   CourseImg = c.Img,
                                   Deleted = c.Deleted
                               }).FirstOrDefaultAsync();
            return course;
        }
        public async Task<Course> GetById_(int id)
        {
            var course = await (from c in db.Courses
                                where c.Id == id
                                select new Course
                                {
                                    Id= c.Id,
                                    CourseName = c.CourseName,
                                    Price = c.Price,
                                    Discount = c.Discount,
                                    LevelId = c.LevelId,
                                    Description = c.Description,
                                    Img = c.Img,
                                    Deleted = c.Deleted
                                }).FirstOrDefaultAsync();
            return course;
        }

        public async Task Update(int id, Course newcourse)
        {
            var course = await (db.Courses.Where(c => c.Id == id)).SingleOrDefaultAsync();
            if (course != null)
            {
                course.Discount = newcourse.Discount;
                course.CourseName = newcourse.CourseName;
                course.Price = newcourse.Price;
                course.Description = newcourse.Description;
                course.LevelId = newcourse.LevelId;
                course.Img = newcourse.Img;
                course.Deleted = newcourse.Deleted;
                await db.SaveChangesAsync();
            }
        }

        public async Task ReActivateCourse(int CourseId)
        {
            var course = await db.Courses.FirstOrDefaultAsync(c => c.Id == CourseId);
            if (course != null)
            {
                course.Deleted = false;
                await db.SaveChangesAsync();
            }
        }
        public async Task<dynamic> GetCourseForAdminById(int id)
        {
            var course = await (from c in db.Courses
                                where c.Id == id
                                select new
                                {
                                    CourseID = c.Id,
                                    CourseName = c.CourseName,
                                    Price = c.Price,
                                    Discount = c.Discount,

                                    LevelId = c.LevelId,
                                    LevelName = c.Level.LevelName,
                                    Description = c.Description,
                                    CourseImg = c.Img,
                                    Deleted = c.Deleted

                                }).SingleOrDefaultAsync();
            return course;
        }

        public async Task<dynamic> GetCourses()
        {
            var courseList = await (from c in db.Courses
                                select new
                                {
                                    CourseID = c.Id,
                                    CourseName = c.CourseName,
                                    Price = c.Price,
                                    Discount = c.Discount,

                                    LevelId = c.LevelId,
                                    LevelName = c.Level.LevelName,
                                    Description = c.Description,
                                    CourseImg = c.Img,
                                    Deleted = c.Deleted

                                }).ToListAsync();
            
            return courseList.Cast<dynamic>().ToList();
        }

        public async Task<bool> reactiveCourse(int courseId)
        {
            var course = await db.Courses.SingleOrDefaultAsync(c => c.Id == courseId);
            if(course.Deleted ==  false)
            {
                return false;
            }
            course.Deleted = false;
            await db.SaveChangesAsync();
            return true;
        }
    }
}
