using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using TuEntradaYa.Models.Enums;

namespace TuEntradaYa.Models.Entities
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]  
        [StringLength(50)]  
        public string LastName { get; set; } = string.Empty;

        [Required]  
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        private Role _role;

        public string Role
        {
            get => _role.ToString();
            set
            {
                if (Enum.TryParse(value, true, out Role parsedRole)) 
                {
                    _role = parsedRole; 
                }
                
            }

        }

    }
}
