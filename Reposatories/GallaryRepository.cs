using ProductGallary.Models;

namespace ProductGallary.Reposatories
{
    public class GallaryRepository : IReposatory<Gallary>
    {
        Context context;
        public GallaryRepository(Context context)
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

        public List<Gallary> GetAll()
        {
            return context.Gallaries.ToList();
        }

        public Gallary GetById(Guid id)
        {
            return context.Gallaries.FirstOrDefault(x=>x.Id==id);
        }

        public bool Insert(Gallary item)
        {
            try
            {
                context.Gallaries.Add(item);
                context.SaveChanges();
                return true;


            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(Guid id, Gallary item)
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
