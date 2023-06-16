using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.Category;

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
    public ActionResult<IQueryable<CategoryDTO>> Get()
    {
        return Ok(_mapper.ProjectTo<CategoryDTO>(_categoryRepo.GetAll()));
    }

    [EnableQuery]
    public async Task<ActionResult<CategoryDTO>> Get([FromRoute] int key)
    {
        var category = await _categoryRepo.Get(key);

        if (category == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<CategoryDTO>(category));
    }
}
