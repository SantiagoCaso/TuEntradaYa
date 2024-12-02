using System.ComponentModel.DataAnnotations;

namespace TuEntradaYa.Models.Dtos.Categories
{
    public class CreateCategoryDto
    {
        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;
    }
}
