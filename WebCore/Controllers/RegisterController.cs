using Microsoft.AspNetCore.Mvc;
using WebCore.Domain.Models;
using WebCore.Service.Implementations;
using WebCore.Service.Interfaces;

namespace WebCore.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _appEnvironment;

        public RegisterController(IUserService userService, IWebHostEnvironment appEnvironment)
        {
            _userService = userService;
            _appEnvironment = appEnvironment;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(User user, IFormFile uploadedFile)
        {
            await _userService.AddUser(user, _appEnvironment.ContentRootPath, uploadedFile);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View("Register");
        }
    }
}
