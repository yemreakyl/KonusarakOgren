using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.EntityModels;
using NLayer.Core.Services;
using NLayer.Web.Models;
using System.Diagnostics;

namespace NLayer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly UserManager<UserApp> _userManager;
        private readonly SignInManager<UserApp> _signInManager;

        public HomeController(ILogger<HomeController> logger, IUserService userService, UserManager<UserApp> userManager, SignInManager<UserApp> signInManager)
        {
            _logger = logger;
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

      

       
        public async Task<IActionResult> LogIn(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                UserApp user = await _userManager.FindByEmailAsync(loginDto.Email);
                if(user != null)
                {
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result=await _signInManager.PasswordSignInAsync(user,loginDto.Password,false,false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Member");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Geçersiz Email adresi ya da şifre");
                }
            }
            return View();
        }


        public async Task<IActionResult> SignUp()
        {
            return  View();
        }


        [HttpPost]
        public async Task<IActionResult> SignUp(CreateUserDto createUserDto)
        {
            if (ModelState.IsValid)
            {


                var Result = await _userService.CreateUserAsync(createUserDto);
                if (Result.Succeeded)
                {
                    return RedirectToAction("LogIn");
                }
                else
                {
                    foreach (var item in Result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(createUserDto);
        }
    }
}