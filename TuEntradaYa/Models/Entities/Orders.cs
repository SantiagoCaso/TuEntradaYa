using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuEntradaYa.Models.Entities
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateAt { get; set; }

        public int UserId {  get; set; }

        [ForeignKey("UserId")]
        public Users? Users { get; set; }
        public float Total { get; set; }    


    }
}
