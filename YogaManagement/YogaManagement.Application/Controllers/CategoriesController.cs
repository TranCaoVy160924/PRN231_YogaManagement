using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.Category.Response;
using YogaManagement.Contracts.Course.Response;

namespace YogaManagement.Application.Controllers;
public class CategoriesController : ODataController
{
    private readonly IMapper _mapper;
    private readonly CategoryRepository _categoryRepo;

    public CategoriesController(CategoryRepository categoryRepository, IMapper mapper)
    {
        _mapper = mapper;
        _categoryRepo = categoryRepository;
    }

    [EnableQuery(PageSize = 10)]
    public ActionResult<IQueryable<CategoryResponse>> Get()
    {
        return Ok(_mapper.ProjectTo<CourseResponse>(_categoryRepo.GetAll()));
    }
    [EnableQuery]
    public async Task<ActionResult<CategoryResponse>> Get([FromRoute] int key)
    {
        var category = await _categoryRepo.Get(key);

        if (category == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<CategoryResponse>(category));
    }
}
