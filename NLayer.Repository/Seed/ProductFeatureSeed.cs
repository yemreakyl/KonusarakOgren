using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.EntityModels;

namespace NLayer.Repository.Seed
{
    internal class ProductFeatureSeed : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasData(
                new ProductFeature() { Id = 1, Color = "Kırmızı", Width = 10, Height = 15, ProductId = 1, },
                new ProductFeature() { Id = 2, Color = "Mavi", Width = 7, Height = 12, ProductId = 2, },
                new ProductFeature() { Id = 3, Color = "Sarı", Width = 9, Height = 17, ProductId = 3, },
                new ProductFeature() { Id = 4, Color = "Turuncu", Width = 4, Height = 15, ProductId = 4, },
                new ProductFeature() { Id = 5, Color = "Yeşil", Width = 2, Height = 13, ProductId = 5, },
                new ProductFeature() { Id = 6, Color = "Beyaz", Width = 6, Height = 15, ProductId = 6, },
                new ProductFeature() { Id = 7, Color = "Mor", Width = 11, Height = 12, ProductId = 7, },
                new ProductFeature() { Id = 8, Color = "Siyah", Width = 5, Height = 15, ProductId = 8, },
                new ProductFeature() { Id = 9, Color = "Kırmızı", Width = 9, Height = 25, ProductId = 9, },
                new ProductFeature() { Id = 10, Color = "Beyaz", Width = 6, Height = 13, ProductId = 10, },
                new ProductFeature() { Id = 11, Color = "Yeşil", Width = 8, Height = 5, ProductId = 11, },
                new ProductFeature() { Id = 12, Color = "Sarı", Width = 3, Height = 45, ProductId = 12, },
                new ProductFeature() { Id = 13, Color = "Siyah", Width = 7, Height = 35, ProductId = 13, }
                );

        }
    }
}
