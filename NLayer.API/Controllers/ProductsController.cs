using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.EntityModels;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{

    public class ProductsController : CusomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;

        public ProductsController( IMapper mapper, IProductService productService)
        {
         
            _mapper = mapper;
            _service = productService;
        }

        [ServiceFilter((typeof(NotFoundFilter<Product>)))]//Burada fitremi ekledim ancak validation filtresi gibi direk ekleyemedim çünkü NotFoundFilter classım bir attribute miras almıyor yada yapıcı methodunda parametre alıyor bu yüzden önce program cs de ekledim sonrada burada servicefilter classı içinde ekledim

      
        [HttpGet]
        public async Task<IActionResult> All()
        {

            var Products = await _service.GetAllAsync();
            var ProductsDtos = _mapper.Map<List<ProductDto>>(Products.ToList());
            return CreateActionResult<List<ProductDto>>(CustomResponseDto<List<ProductDto>>.Success(200, ProductsDtos));
        }

     
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var Product = await _service.GetByIdAsync(id);
            var ProductsDto = _mapper.Map<ProductDto>(Product);

            return CreateActionResult<ProductDto>(CustomResponseDto<ProductDto>.Success(200,ProductsDto));

        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var Product = await _service.AddAsync(_mapper.Map<Product>(productDto)); 
            var ProductsDto = _mapper.Map<ProductDto>(Product);

            return CreateActionResult<ProductDto>(CustomResponseDto<ProductDto>.Success(201, ProductsDto));//201:Created kodu

        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));
            return CreateActionResult<NoContentDto>(CustomResponseDto<NoContentDto>.Success(204));//201:Created kodu

        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var Product= await _service.GetByIdAsync(id);
            await _service.RemoveAsync(Product);
            return CreateActionResult<NoContentDto>(CustomResponseDto<NoContentDto>.Success(200));

        }
    }
}
