using System.ComponentModel.DataAnnotations;
using TuEntradaYa.Models.Enums;

namespace TuEntradaYa.Models.Dtos.User
{
    public class UserCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;
        public Role Role = Role.User;
    }
}
