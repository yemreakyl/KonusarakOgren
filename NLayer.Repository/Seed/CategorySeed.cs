using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.EntityModels;

namespace NLayer.Repository.Seed
{
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        //Seed dosyasında yaptığım işler aslında veri tabanında tablolarım oluşurken içerilerine default olarak değerler atamak maksadıyla yaptığım işlemleri içeriyor.IEntityTypeConfiguration interfacesini implement ettiğim için aynı configurations dosyasında olduğu gibi AppDbContex classımda yer alan override ettiğim model builder methodum bu dosyadaki class ları görebilecek

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Name = "Kalemler" },
                new Category { Id = 2, Name = "Kitaplar" },
                new Category { Id = 3, Name = "Defterler" },
                new Category { Id = 4, Name = "Telefonlar" },
                new Category { Id = 5, Name = "Bilgisayarlar" }
                            );
        }
    }
}
