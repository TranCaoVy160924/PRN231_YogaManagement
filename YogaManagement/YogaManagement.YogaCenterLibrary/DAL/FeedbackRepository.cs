using Microsoft.EntityFrameworkCore;
using YogaCenterLibrary.Models;
using YogaCenterAPIV2.Repositories;

namespace YogaCenterAPIV2.DAL
{
    public class FeedbackRepository : IRepository<Feedback>
    {
        YogaCenterContext db = new YogaCenterContext();
        public FeedbackRepository() { }

        public async Task Add(Feedback feedback)
        {
            Feedback newFeedback = new Feedback { Id = feedback.Id, TraineeId = feedback.TraineeId, CourseId = feedback.CourseId, Rating = feedback.Rating, Status = feedback.Status, Description = feedback.Description };
            newFeedback.Status = YogaCenterAPIV2.Utils.Constant.FeedbackStatus.UNCHECKED;
            await db.Feedbacks.AddAsync(newFeedback);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var feedbackToDelete = await db.Feedbacks.FirstOrDefaultAsync(f => f.Id == id);
            if (feedbackToDelete != null)
            {
                feedbackToDelete.Status = 1;
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<dynamic>> GetAll()
        {
            var feedbackList = await (from f in db.Feedbacks
                                      join c in db.Courses on f.CourseId equals c.Id
                                      where f.Status == YogaCenterAPIV2.Utils.Constant.FeedbackStatus.APPROVED
                                      select new
                                      {
                                          id = f.Id,
                                          TraineeId = f.TraineeId,
                                          CourseId = f.CourseId,
                                          Rating = f.Rating,
                                          Status = f.Status,
                                          Description = f.Description,
                                          Coursename = c.CourseName
                                      }).ToArrayAsync();
            return feedbackList.Cast<dynamic>().ToList();
        }

        public async Task<dynamic> GetById(int id)
        {
            var feedbackDetail = await (from f in db.Feedbacks
                                        join c in db.Courses on f.CourseId equals c.Id
                                        join a in db.Accounts on f.TraineeId equals a.Id
                                        where f.Id == id && f.Status == YogaCenterAPIV2.Utils.Constant.FeedbackStatus.APPROVED
                                        select new
                                        {
                                            rating = f.Rating,
                                            Description = f.Description,
                                            traineeId = a.Id,
                                            Firstname = a.Firstname,
                                            Lastname = a.Lastname,
                                            Img = a.Img
                                        }).FirstOrDefaultAsync();
            return feedbackDetail;
        }

        public async Task Update(int id, Feedback feedbackUpdate)
        {
            var oldFeedback = db.Feedbacks.FirstOrDefault(f => f.Id == id);
            if (oldFeedback != null)
            {
                oldFeedback.TraineeId = feedbackUpdate.TraineeId;
                oldFeedback.CourseId = feedbackUpdate.CourseId;
                oldFeedback.Rating = feedbackUpdate.Rating;
                oldFeedback.Description = feedbackUpdate.Description;
                oldFeedback.Status = feedbackUpdate.Status;
                await db.SaveChangesAsync();
            }

        }

        public async Task<dynamic> GetFeedBackDetailForAdmin(int feedbackId)
        {
            var feedbackDetail = await (from f in db.Feedbacks
                                        join c in db.Courses on f.CourseId equals c.Id
                                        join a in db.Accounts on f.TraineeId equals a.Id
                                        where f.Id == feedbackId
                                        select new
                                        {
                                            id = f.Id,
                                            traneeId = a.Id,
                                            CourseId = f.CourseId,
                                            rating = f.Rating,
                                            Status = f.Status,
                                            Description = f.Description,
                                            Coursename = c.CourseName,
                                            Firstname = a.Firstname,
                                            Lastname = a.Lastname,
                                            Img = a.Img
                                        }).FirstOrDefaultAsync();
            return feedbackDetail;
        }
        public async Task<List<dynamic>> GetCourseFeedback(int courseId)
        {
            var feedbacList = await (from f in db.Feedbacks
                                     join c in db.Courses on f.CourseId equals c.Id
                                     where c.Id == courseId && f.Status == YogaCenterAPIV2.Utils.Constant.FeedbackStatus.APPROVED
                                     select new
                                     {
                                         id = f.Id,
                                         TraineeId = f.TraineeId,
                                         CourseId = courseId,
                                         Rating = f.Rating,
                                         Status = f.Status,
                                         Description = f.Description,
                                         Coursename = c.CourseName
                                     }).ToArrayAsync();
            return feedbacList.Cast<dynamic>().ToList();
        }

        public async Task<List<dynamic>> GetCourseFeedbackForStaff(int courseId)
        {
            var feedbacList = await (from f in db.Feedbacks
                                     join c in db.Courses on f.CourseId equals c.Id
                                     where c.Id == courseId
                                     select new
                                     {
                                         id = f.Id,
                                         TraineeId = f.TraineeId,
                                         CourseId = courseId,
                                         Rating = f.Rating,
                                         Status = f.Status,
                                         Description = f.Description,
                                         Coursename = c.CourseName
                                     }).ToArrayAsync();
            return feedbacList.Cast<dynamic>().ToList();
        }
    }
}
