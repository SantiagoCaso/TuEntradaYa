using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TuEntradaYa.Models.Dtos.Categories;
using TuEntradaYa.Models.Entities;
using TuEntradaYa.Services.Implementations;
using TuEntradaYa.Services.Interfaces;

namespace TuEntradaYa.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) 
        {
           _categoryService = categoryService;
        }

        [HttpGet("all-categories")]
        public ActionResult<List<Categories>> GetAllCategories() 
        {
            return Ok(_categoryService.GetAllCategories());
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public IActionResult AddCategory([FromBody] CreateCategoryDto category)
        {
            bool addCategory = _categoryService.AddCategory(category);
            return Ok("Se ha creado La categoria: " + category.Category);
        }
    }
}
