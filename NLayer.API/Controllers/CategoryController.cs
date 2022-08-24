using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Services;
using NLayer.Service.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CusomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("[action]/{Categoryid}")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProductsAsync(int Categoryid)
        {
            return CreateActionResult(await _categoryService.GetSingleCategoryByIdWithProductsAsync(Categoryid));
        }
    }
}
