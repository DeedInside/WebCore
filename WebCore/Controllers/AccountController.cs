using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebCore.Domain.Models;
using WebCore.Modele;
using WebCore.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebCore.Controllers
{
    public class AccountController : Controller
    {
        public IUserService userService;
        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Name != null && model.Password != null)
                {
                    var user = await userService.GetOneUser(model.Name, model.Password);
                    await Authenticate(user.Data); // autorization user

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
            }
            return NotFound();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Account()
        {
            return View();
        }
        private async Task Authenticate(User user)
        {
            if(user.ImageUrl == null)
            {
                user.ImageUrl = "/image/Undefine.jpeg";
            }
            if (user != null && user.Name != null )
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name),
                new Claim("ImageUser", user.ImageUrl)
            };
                // creat object ClaimsIdentity
                ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                // unstall Authentication Cookie
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
