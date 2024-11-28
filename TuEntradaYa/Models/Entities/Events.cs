using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace TuEntradaYa.Models.Entities
{
    public class Events
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Event { get; set; } = string.Empty;

        [Required]
        public int NumberTikets { get; set; }

        public string EventPlace { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        public string EventDescription  { get; set; } = string.Empty;

    }
}
