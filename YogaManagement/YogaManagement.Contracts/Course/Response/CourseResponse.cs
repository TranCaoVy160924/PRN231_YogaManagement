using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaManagement.Contracts.Course.Response;
public class CourseResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EnddDate { get; set; }
    public bool IsActive { get; set; }

    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}
