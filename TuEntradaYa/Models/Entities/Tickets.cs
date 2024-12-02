using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuEntradaYa.Models.Entities
{
    public class Tickets
    {
        [Key]
        public int Id { get; set; }

        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public Events? Event {  get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Categories? Category { get; set; }
    }
}
