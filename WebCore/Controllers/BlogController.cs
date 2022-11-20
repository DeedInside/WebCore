using Microsoft.AspNetCore.Mvc;

namespace WebCore.Controllers
{
	public class BlogController : Controller
	{
		public IActionResult Blog()
		{
			return View();
		}
	}
}
