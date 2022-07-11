using ProductGallary.Models;

namespace ProductGallary.Reposatories
{
    public class GallaryRepesitory : IReposatory<GallaryRepesitory>
    {
        Context context;
        public GallaryRepesitory(Context context)
        {
            this.context = context;
        }

        public bool Delete(Guid id)
        {
            try
            {
                var item = GetById(id);
                context.Gallaries.Remove(item);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<GallaryRepesitory> GetAll()
        {
            return context.Gallaries.ToList();
        }

        public GallaryRepesitory GetById(Guid id)
        {
            return context.Gallaries.FirstOrDefault(e => e.Id == id);
        }

        public bool Insert(GallaryRepesitory item)
        {
            throw new NotImplementedException();
        }

        public bool Update(Guid id, GallaryRepesitory item)
        {
            Gallary oldgallary = GetById(id);
            try
            {
                oldgallary.Name = item.Name;
                oldgallary.Logo = item.Logo;
                oldgallary.Created_Date = item.Created_Date;
                oldgallary.User_Id = item.User_Id;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
