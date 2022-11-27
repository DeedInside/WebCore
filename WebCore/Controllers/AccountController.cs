using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebCore.Domain.Models;
using WebCore.Modele;
using WebCore.Service.Interfaces;

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
        public IActionResult Account()
        {
            return View();
        }
        private async Task Authenticate(User user)
        {
            if (user != null && user.Name != null )
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
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
