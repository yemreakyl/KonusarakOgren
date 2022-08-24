﻿using Microsoft.EntityFrameworkCore;
using NLayer.Core.EntityModels;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext contex) : base(contex)
        {
        }

        public async Task<Category> GetSingleCategoryByIdWithProductsAsync(int CategoryId)
        {
            return await _context.Categories.Include(x=>x.Products).Where(x=>x.Id==CategoryId).SingleOrDefaultAsync();
           
        }
    }
}
