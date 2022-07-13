using System.ComponentModel.DataAnnotations;

namespace ProductGallary.TDO
{
    public class ProductCreateTDO
    {

        [Required]
        public string? Name { get; set; }

        [Required]
        public IFormFile? Image { get; set; }

        [Required]
        public float? Price { get; set; }

        public bool? HasDiscount { get; set; }

        public float? DiscountPercentage { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
