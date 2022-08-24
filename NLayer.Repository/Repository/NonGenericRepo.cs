using NLayer.Core.DTOs;
using NLayer.Core.EntityModels;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repository
{
    public class NonGenericRepo:INonGenericRepository
    {
        protected readonly AppDbContext _context;

        public NonGenericRepo(AppDbContext context)
        {
            _context = context;
        }

       

        public async Task AddProductWithFeatures(Product product, ProductFeature productFeature)
        {
           await _context.Products.AddAsync(product);
           await _context.ProductFeatures.AddAsync(productFeature);
            
        }
    }
}
