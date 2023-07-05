using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaCenterLibrary.DTO
{
    public class DashboardStatistic
    {
        public int NumOfAdmin { get; set; }
        public int NumOfStaff { get; set; }
        public int NumOfTrainer { get; set; }
        public int NumOfTrainee { get; set; }
        public int NumOfCourse { get; set; }
        public int NumOfClass { get; set; }
        public int NumOfBlog { get; set; }
        public int NumOfFeedback { get; set; }

        public double TotalRevenue { get; set; }
        public DashboardStatistic() { }
    }
}
