using System.ComponentModel.DataAnnotations;

namespace ProductGallary.TDO
{
    public class GalaryCreateDTO
    {
        [Display(Name = "اسم الفئه  :")]
        [Required(ErrorMessage = "اسم الفئه مطلوب *")]
        public string CategoryName { get; set; }
    }
}
