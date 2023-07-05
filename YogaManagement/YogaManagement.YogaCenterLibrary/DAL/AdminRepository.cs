using Microsoft.EntityFrameworkCore;
using YogaCenterLibrary.Models;
using YogaCenterAPIV2.Utils;
using YogaCenterLibrary.DTO;
namespace YogaCenterAPIV2.DAL
{
    public class AdminRepository
    {
        YogaCenterContext db = new YogaCenterContext();
            

        public async Task<dynamic> GetOveralStatistics()
        {
            var numberOfAdmin = await getNumberOfAccountByRoleId(Constant.Role.ADMIN_ROLEID);
            var numberOfStaff = await getNumberOfAccountByRoleId(Constant.Role.STAFF_ROLEID);
            var numberOfTrainer = await getNumberOfAccountByRoleId(Constant.Role.TRAINER_ROLEID);
            var numberOfTrainee = await getNumberOfAccountByRoleId(Constant.Role.TRAINEE_ROLEID);
            var numberOfCourse = await GetNumberOfCourse();
            var numberOfClass = await GetNumberOfClass();
            var numberOfBlog = await GetNumberOfBlog();
            var numberOfFeedback = await GetNumberOfFeedback();

            var totalRevenue = await GetCourseRevenue();
            var result = new DashboardStatistic
            {
                NumOfAdmin = numberOfAdmin,
                NumOfStaff = numberOfStaff,
                NumOfTrainer = numberOfTrainer,
                NumOfTrainee = numberOfTrainee,
                NumOfCourse = numberOfCourse,
                NumOfClass = numberOfClass,
                NumOfBlog = numberOfBlog,
                NumOfFeedback = numberOfFeedback,
                TotalRevenue = totalRevenue
            };

            return result;
        }
        private async Task<int> GetNumberOfBlog()
        {
            var numberOfBlog = await db.Blogs.CountAsync();
            return numberOfBlog;
        }
        private async Task<int> GetNumberOfClass()
        {

            var numberOfClass = await db.Classes.CountAsync();
            return numberOfClass;
        }
        private async Task<int> GetNumberOfFeedback()
        {
            var numberOfCourse = await db.Feedbacks.CountAsync();
            return numberOfCourse;
        }

        private async Task<int> GetNumberOfCourse()
        {
            var numberOfCourse = await db.Courses.CountAsync();
            return numberOfCourse;
        }

        private async Task<int> getNumberOfAccountByRoleId(int roleId)
        {
            if (roleId < Constant.Role.ADMIN_ROLEID || roleId > Constant.Role.TRAINEE_ROLEID)
            {
                return 0;
            }

            var numberOfAccount = await db.Accounts.CountAsync(a => a.RoleId == roleId);
            return numberOfAccount;
        }

        private async Task<dynamic> GetCourseRevenue()
        {
            var annualRevenue = await (from b in db.Bookings
                                       where b.Status == Constant.Booking.FAIL_REFUND
                                       select b.Amount).SumAsync();
            return annualRevenue;
        }
    }
    }

