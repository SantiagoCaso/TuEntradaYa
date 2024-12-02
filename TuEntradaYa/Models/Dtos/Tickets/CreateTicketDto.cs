using System.ComponentModel.DataAnnotations.Schema;

namespace TuEntradaYa.Models.Dtos.Tickets
{
    public class CreateTicketDto
    {
        public int EventId { get; set; }

        public int CategoryId { get; set; }
        
    }
}
