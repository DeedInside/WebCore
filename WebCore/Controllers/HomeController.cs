using Microsoft.AspNetCore.Mvc;

namespace WebCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
