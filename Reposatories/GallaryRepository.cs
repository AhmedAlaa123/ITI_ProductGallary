using ProductGallary.Models;
using ProductGallary.TDO;

namespace ProductGallary.Reposatories
{
    public class GallaryRepository :IReposatory<Gallary>
    {
        Context context;
        public  GallaryRepository(Context context)
        {
            this.context = context;
        }

        public List<Gallary> GetAll()
        {

            return context.Gallaries.ToList();
        }

        public Gallary GetById(Guid id)
        {
            return context.Gallaries.FirstOrDefault(e=>e.Id==id);
        }

        public void Insert(Gallary item)
        {
            
            try
            {
                context.Gallaries.Add(item);
                context.SaveChanges();


            }
            catch (Exception )
            {
               

            }
        }

        public bool Update(Guid id, Gallary item)
        {
           Gallary oldgallary=GetById(id);
            try
            {
                oldgallary.Name = item.Name;
                oldgallary.Logo = item.Logo;
                oldgallary.Created_Date =item.Created_Date; 
                oldgallary.User_Id = item.User_Id;
                return true;
            }
            catch (Exception)
            {
                return false;
            }

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

        bool IReposatory<Gallary>.Insert(Gallary item)
        {
            throw new NotImplementedException();
        }
    }
}
