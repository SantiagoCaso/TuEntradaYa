using TuEntradaYa.Models.Dtos.Categories;
using TuEntradaYa.Models.Entities;

namespace TuEntradaYa.Services.Interfaces
{
    public interface ICategoryService
    {
        List<Categories> GetAllCategories();

       bool AddCategory(CreateCategoryDto category);
    }
}
