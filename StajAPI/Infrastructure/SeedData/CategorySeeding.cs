using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StajAPI.Models.Concrete;

namespace StajAPI.Infrastructure.SeedData
{
    public class CategorySeeding : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { ID = 1, Name = "Gida" },
                new Category { ID = 2, Name = "Beyaz Esya" },
                new Category { ID = 3, Name = "Kucuk Ev Aletleri" },
                new Category { ID = 4, Name = "Aksesuar" },
                new Category { ID = 5, Name = "Kiyafet" }
                );
        }
    }
}
