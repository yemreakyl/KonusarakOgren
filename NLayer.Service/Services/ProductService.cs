using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.EntityModels;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

       

        public async Task<List<ProductWithCategoryDto>> GetProductsWithCategory()
        {
            var products = await _productRepository.GetProductsWitCategory();

            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
            return productsDto;
        }
    }

}
