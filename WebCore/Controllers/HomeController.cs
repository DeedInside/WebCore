using Microsoft.AspNetCore.Mvc;
using WebCore.Service.Implementations;
using WebCore.Service.Interfaces;

namespace WebCore.Controllers
{
    public class HomeController : Controller
    {
        public IUserService UserService;

        public HomeController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await UserService.GetUsers();

            return View(response.Data);
        }
    }
}
