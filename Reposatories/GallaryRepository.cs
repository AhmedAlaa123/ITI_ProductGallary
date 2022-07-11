﻿using ProductGallary.Models;

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
                context.SaveChanges();
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

        public bool Update(Guid id, Gallary newgall)
        {
            try
            {
           Gallary oldgallary = GetById(id);
            oldgallary.Name = newgall.Name;
            oldgallary.Logo = newgall.Logo;
            oldgallary.Created_Date=DateTime.Now;
            context.SaveChanges();
            return true;

            }
            catch (Exception)
            {

                return false;
            }
            
        }
    }
}
