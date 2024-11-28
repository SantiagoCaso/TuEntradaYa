using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TuEntradaYa.Models.Entities;

namespace TuEntradaYa.Models.Dtos.Orders
{
    public class OrderCreateDto
    {
        [DataType(DataType.Date)]
        public DateTime CreateAt { get; set; }

        public int UserId { get; set; }

        public float Total { get; set; }
    }
}
