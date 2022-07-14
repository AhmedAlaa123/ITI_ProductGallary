using ProductGallary.Models;

namespace ProductGallary.Reposatories
{
    public interface CartInterface
    {
        bool Add(Cart item);
        bool Delete(Guid id);
        Cart GetById(Guid id);


    }
}
