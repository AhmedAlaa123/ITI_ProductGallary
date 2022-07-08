namespace ProductGallary
{
    public interface IReposatory<T>
    {

        //Get All items
        List<T> GetAll();

        // get by id
        T GetById(int id);  
        // insert
        bool Insert(T item);    
        // update
        bool Update(T item);    

        // delete
        bool Delete(T item);    



    }
}
