using Microsoft.EntityFrameworkCore;
using StajAPI.Infrastructure.SeedData;
using StajAPI.Models.Concrete;

namespace StajAPI.Context
{
    public class StajApiDbContext:DbContext
    {
        //Constructor alacak dependency injectio nmetodu yapacağız.
        public StajApiDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategorySeeding());//Migration yaparken dataları ekleyecek.
            base.OnModelCreating(modelBuilder);
        }
    }
}
