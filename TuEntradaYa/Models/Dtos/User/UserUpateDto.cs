using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace TuEntradaYa.Models.Dtos.User
{
    public class UserUpateDto
    {
        
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string?  Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = string.Empty;
    }
}
