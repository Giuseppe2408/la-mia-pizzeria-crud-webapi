using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository _categoryRepository)
        {
            
            categoryRepository = _categoryRepository;
            
        }

        public IActionResult Get()
        {
            List<Category> categoryList = categoryRepository.All();


            return Ok(categoryList);
        }

        public IActionResult SearchById(int id)
        {
            Category category = categoryRepository.SearchById(id);


            return Ok(category);
        }

    }
}
