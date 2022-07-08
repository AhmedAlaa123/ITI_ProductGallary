using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductGallary.Models
{
    [Table("OrderProductList")]
    public class OrderProductList
    {

        [Key]
        public Guid Id { get; set; }

        public virtual List<Product> Products { get; set; }

        public virtual List<Order> Orders{ get; set; }


    }
}
