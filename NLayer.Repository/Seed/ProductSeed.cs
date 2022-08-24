using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.EntityModels;

namespace NLayer.Repository.Seed
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Name = "Kalem 1", CreatedDate = DateTime.Now, Id = 1, CategoryId = 1, Price = 150, Stock = 30, },
                new Product { Name = "Kalem 2", CreatedDate = DateTime.Now, Id = 2, CategoryId = 1, Price = 110, Stock = 50, },
                new Product { Name = "Kalem 3", CreatedDate = DateTime.Now, Id = 3, CategoryId = 1, Price = 170, Stock = 60, },

                new Product { Name = "Kitap 1", CreatedDate = DateTime.Now, Id = 4, CategoryId = 2, Price = 130, Stock = 90, },
                new Product { Name = "Kitap 2", CreatedDate = DateTime.Now, Id = 5, CategoryId = 2, Price = 120, Stock = 80, },
                new Product { Name = "Kitap 3", CreatedDate = DateTime.Now, Id = 6, CategoryId = 2, Price = 110, Stock = 90, },

                new Product { Name = "Defter 1", CreatedDate = DateTime.Now, Id = 7, CategoryId = 3, Price = 130, Stock = 90, },
                new Product { Name = "Defter 1", CreatedDate = DateTime.Now, Id = 8, CategoryId = 3, Price = 100, Stock = 90, },
                new Product { Name = "Defter 1", CreatedDate = DateTime.Now, Id = 9, CategoryId = 3, Price = 90, Stock = 90, },

                new Product { Name = "İphoneX", CreatedDate = DateTime.Now, Id = 10, CategoryId = 4, Price = 10040, Stock = 30, },
                new Product { Name = "SamsungS20", CreatedDate = DateTime.Now, Id = 11, CategoryId = 4, Price = 18000, Stock = 20, },

                new Product { Name = "LG5004", CreatedDate = DateTime.Now, Id = 12, CategoryId = 5, Price = 12000, Stock = 40, },
                new Product { Name = "SamsungQ70T", CreatedDate = DateTime.Now, Id = 13, CategoryId = 5, Price = 14040, Stock = 25, }

                );
        }
    }
}
