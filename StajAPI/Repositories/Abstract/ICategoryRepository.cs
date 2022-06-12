using StajAPI.Models.Concrete;

namespace StajAPI.Repositories.Abstract
{
    public interface ICategoryRepository:IRepository<Category>
    {
        //neden iRepository'yi bir classa implemente etmek yerine bunu açtım?
        //IRepository projedeki tüm repostoryler için geçerli standartı oluşturuyor. 
        //Ama category için kategori özelinde CategoryInProduct diye bir metodum olabilir. Dolayısıyla ek metotlar için bunu
        //oluşturuyorum...


    }
}
