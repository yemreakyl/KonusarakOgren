using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seed
{
    public class CommentSeed : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData(
                    new Comment { Id = 1, Content = "Ürün çok güzeldi", CreatedDate = DateTime.Now, ProductId = 3, UserName = "Emre" },
                    new Comment { Id = 2, Content = "Ürün çok kötüydü", CreatedDate = DateTime.Now, ProductId = 2, UserName = "ahmet"},
                    new Comment { Id = 3, Content = "Ürün çok kötüydü", CreatedDate = DateTime.Now, ProductId = 5, UserName = "Tuğçe" },
                    new Comment { Id = 4, Content = "Ürün idare eder", CreatedDate = DateTime.Now, ProductId = 11, UserName = "selim"  }
                );
        }
    }
}
