using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuEntradaYa.Models.Entities
{
    public class OrdersDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int Id { get; set; }

        public int NumberOfTikets { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public Users ? User {  get; set; }

        public int OrderId { get; set; }    

        [ForeignKey("OrderId")]
        public Orders? Orders { get; set; }

        public int TicketId { get; set; } // esto tiene que ser un array de los Id de los tikets

        [ForeignKey("TicketId")]
        public Tickets? Tickets { get; set; }
    }

}
