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
    public class NonGenericService : INonGenericService
    {
        private readonly INonGenericRepository _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NonGenericService(INonGenericRepository repo, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddProductWithFeatures(ProductDto productDto, ProductFeatureDto productFeatureDto)
        {
            var product=_mapper.Map<Product>(productDto);
            var productFeature=_mapper.Map<ProductFeature>(productFeatureDto);
            await _repo.AddProductWithFeatures(product, productFeature);
            await _unitOfWork.CommitAsync();
        }
    }
}
