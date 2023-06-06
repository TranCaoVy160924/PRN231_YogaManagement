using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaManagement.Business.Repositories;
using YogaManagement.Domain.Models;

namespace YogaManagement.Business.Services.CourseService;
public class CourseService: ICourseService
{
    private readonly RepositoryBase<Course> _courseRepo;

    public CourseService(RepositoryBase<Course> courseRepo)
    {
        _courseRepo = courseRepo;
    }
}
