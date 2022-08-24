using Microsoft.EntityFrameworkCore;
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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext contex) : base(contex)
        {
        }

       

        public async Task<List<Product>> GetProductsWitCategory()
        {

            return await _context.Products.Include(x => x.Category).ToListAsync();
        }

        
    }
}
