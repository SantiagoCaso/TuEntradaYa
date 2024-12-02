using TuEntradaYa.DBContext;
using TuEntradaYa.Models.Dtos.Categories;
using TuEntradaYa.Models.Entities;
using TuEntradaYa.Services.Interfaces;

namespace TuEntradaYa.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly TuEntradaYaContext _tuEntradaYaContext;

        public CategoryService(TuEntradaYaContext tuEntradaYaContext)
        {
            _tuEntradaYaContext = tuEntradaYaContext;
        }

        public List<Categories> GetAllCategories()
        {
           return  _tuEntradaYaContext.Categories.ToList();

        }

        public bool AddCategory(CreateCategoryDto category)
        {
            Categories addCategory = new Categories()
            {
                Category = category.Category,
            };

            _tuEntradaYaContext.Categories.Add(addCategory);
            _tuEntradaYaContext.SaveChanges();
            return true;
        }
    }
}
