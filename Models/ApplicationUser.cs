using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductGallary.Models
{
    [Table("User")]
    public class ApplicationUser:IdentityUser
    {
        
        [Required]
        [MaxLength(40),MinLength(10)]
        public string Name { get; set; }

        [Required,MinLength(5),MaxLength(30)]
        public string Address { get; set; }

        public Cart Cart { get; set; }

        public virtual List<Product>Products { get; set; }
        public virtual List<Gallary> Gallaries { get; set; }

        public virtual List<Category> Categories { get; set; }


    }
}
