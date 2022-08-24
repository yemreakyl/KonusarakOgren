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
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

       
        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductsAsync(int CategoryId)
        {
            var CategoryWithProduct = await _categoryRepository.GetSingleCategoryByIdWithProductsAsync(CategoryId);
            var CategoryWithProductsDto = _mapper.Map<CategoryWithProductsDto>(CategoryWithProduct);
            return CustomResponseDto<CategoryWithProductsDto>.Success(200, CategoryWithProductsDto);
        }

        
    }
}
