using NLayer.Core.DTOs;
using NLayer.Core.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    public interface INonGenericRepository
    {
        Task AddProductWithFeatures(Product product, ProductFeature productFeature);
    }
}
