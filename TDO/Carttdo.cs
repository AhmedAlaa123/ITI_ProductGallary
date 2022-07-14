using ProductGallary.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductGallary.TDO
{
    public class Carttdo
    {
        public Guid Id { get; set; }

        public Guid? Order_Id { get; set; }


    }
}
