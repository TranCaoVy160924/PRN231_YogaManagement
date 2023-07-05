using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaCenterLibrary.DTO
{
    public class MonthlyReport
    {
        public int month { get; set; }
        public int numOfClass { get; set; }
        public int numOfTrainee { get; set; }
        public double monthlyRevenue { get; set; }
        public MonthlyReport(int month, int numOfClass, int numOfTrainee, double? monthlyRevenue)
        {
            this.month = month;
            this.numOfClass = numOfClass;
            this.numOfTrainee = numOfTrainee;
            this.monthlyRevenue = (double)monthlyRevenue;
        }
    }
}
