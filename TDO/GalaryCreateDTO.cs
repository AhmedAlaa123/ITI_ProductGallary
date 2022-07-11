using System.ComponentModel.DataAnnotations;

namespace ProductGallary.TDO
{
    public class GalaryCreateDTO
    {
        [Required, MinLength(3), MaxLength(20)]
        public string name { get; set; }
        [Required]
        public string Logo { get; set; }
    
    }
}
