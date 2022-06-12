using System.Collections.Generic;

namespace StajAPI.Repositories.Abstract
{
    public interface IRepository<T>
    {
        bool Add(T item); //Burada yapılan işlemler yapılırsa yaptım veyua yapmadım diye geri dönüş olması için bool lkullandım.
        bool Edit(T item);
        bool Remove(T item);

        List<T> GetAll();
        T GetByID(int id);
    }
}
