using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductGallary.Models
{
    [Table("Order")]
    public class Order
    {

        [Key]
        public Guid Id { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Required,DataType(DataType.DateTime)]
        public DateTime DeliveryDate { get; set; }

        public Bill Bill { get; set; }

        public OrderProductList OrderProductList { get; set; }

        public Cart Cart{ get; set; }



    }
}
