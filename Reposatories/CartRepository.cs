using Microsoft.EntityFrameworkCore;
using ProductGallary.Models;

namespace ProductGallary.Reposatories
{
    public class CartRepository:CartInterface
    {
        Context context;
        public CartRepository(Context context)
        {
            this.context = context;
        }

        public bool Add(Cart item)
        {
            try
            {
                context.Carts.Add(item);
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
;
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var item = GetById(id);
                context.Carts.Remove(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public Cart GetById(Guid id)
        {
            return context.Carts.FirstOrDefault(x => x.Id == id);
            

        }
    }
}

