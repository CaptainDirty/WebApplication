using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Controllers;
using WebApplication.Data;
using WebApplication.Models;
using WebApplication.Models.LoginViewModels;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        #region -- Login

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var existUser = _context.Users.FirstOrDefault(x => x.Email == viewModel.login && x.Password == viewModel.password);

            if (existUser == null)
            {
                TempData["Message"] = "Неверный логин или пароль";
                return View();
            }

            await Authenticate(existUser);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region -- Register 

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var existUser = _context.Users.FirstOrDefault(x => x.Email == viewModel.login && x.Password == viewModel.password);

            if (existUser != null)
            {
                TempData["Message"] = "Пользователь с таким логином уже существует.";
                return View();
            }

            var user = new User
            {
                Email = viewModel.login,
                Password = viewModel.password
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            await Authenticate(user);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        #endregion

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("UserId", user.UserId.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
