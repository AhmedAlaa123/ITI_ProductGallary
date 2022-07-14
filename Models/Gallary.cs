using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductGallary.Models
{
    [Table("Gallary")]
    public class Gallary
    {

        [Key]
        public Guid Id { get; set; }

        [Required,MinLength(3),MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string Logo { get; set; }

        [Required,DataType(DataType.DateTime)]
        public DateTime Created_Date { get; set; }

        [ForeignKey("User")]
        public string User_Id { get; set; }
        public ApplicationUser User { get; set; }
        public virtual List<Product> Products { get; set; }

    }
}
