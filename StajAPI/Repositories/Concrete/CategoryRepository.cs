using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StajAPI.Context;
using StajAPI.Models.Concrete;
using StajAPI.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace StajAPI.Repositories.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        //burada dependency injection design pattern'ini kullanacağız.
        private readonly DbContext _dbContext;
        public CategoryRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(Category item)
        {
            var category = _dbContext.Set<Category>().Add(item);
            return BoolResult(category);
        }

        public bool Edit(Category item)
        {
            return BoolResult(_dbContext.Set<Category>().Update(item));
        }

        public List<Category> GetAll()
        {
            return _dbContext.Set<Category>().ToList();
            //return _dbContext.Set<Category>().Where(x => x.Status == Enums.Status.Active).ToList();
        }

        public Category GetByID(int id)
        {
            return _dbContext.Set<Category>().Find(id);

        }

        public bool Remove(Category item)
        {
            return BoolResult(_dbContext.Set<Category>().Remove(item));
        }

        bool BoolResult(EntityEntry entity)
        {
            if (entity == null)
            {
                return false;
            }

            var ess= _dbContext.SaveChanges();
            return ess >0? true : false;            
        }
    }
}
