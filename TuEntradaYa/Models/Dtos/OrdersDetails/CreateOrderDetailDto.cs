using System.ComponentModel.DataAnnotations.Schema;
using TuEntradaYa.Models.Entities;

namespace TuEntradaYa.Models.Dtos.OrdersDetails
{
    public class CreateOrderDetailDto
    {
        public int NumberOfTikets { get; set; }

        public int UserId { get; set; }

        public int OrderId { get; set; }

        public int TicketId { get; set; }
   
    }
}
