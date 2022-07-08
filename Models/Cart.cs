using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductGallary.Models
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public string User_Id { get; set; }

        public ApplicationUser User { get; set; }

        [ForeignKey("Order")]
        public Guid Order_Id { get; set; }

        public Order Order { get; set; }


    }
}
