using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core.DTOs;
using NLayer.Core.EntityModels;
using NLayer.Core.Services;

namespace NLayer.Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly IProductService _product;
        private readonly ICategoryService _category;
        private readonly SignInManager<UserApp> _signInManager;
        private readonly IMapper _mapper;

        public MemberController(IProductService product, ICategoryService category, SignInManager<UserApp> signInManager)
        {
            _product = product;
            _category = category;
            _signInManager=signInManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _product.GetProductsWithCategory());
        }
        public void LogOut()
        {
             _signInManager.SignOutAsync();
           
        }
        public async Task<IActionResult> CreateRole()
        {
            return View();
        }



    }
}
