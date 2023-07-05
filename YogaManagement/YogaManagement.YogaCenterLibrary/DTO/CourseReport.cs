using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaCenterLibrary.DTO
{
    public class CourseReport
    {
        public double annualRevenue { get; set; }
        public int numOfClass { get; set; }
        public int numOfTrainee { get; set; }
        public List<MonthlyReport> monthlyReports { get; set; }
    }
}
