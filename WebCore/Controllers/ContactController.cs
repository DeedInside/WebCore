using Microsoft.AspNetCore.Mvc;

namespace WebCore.Controllers
{
    public class ContactController : Controller
    {
        public  IActionResult ContactAsync()
        {     
            return View();
        }
    }
}
