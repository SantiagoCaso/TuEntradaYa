using System.ComponentModel.DataAnnotations;

namespace TuEntradaYa.Models.Dtos.Events
{
    public class EventCreateDto
    {
        [Required]
        [StringLength(100)]
        public string Event { get; set; } = string.Empty;

        [Required]
        public int NumberTikets { get; set; } 

        public string EventPlace { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        public string EventDescription { get; set; } = string.Empty;

    }
}
