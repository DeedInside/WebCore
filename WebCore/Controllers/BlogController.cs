using Microsoft.AspNetCore.Mvc;
using WebCore.Domain.Models;
using WebCore.Service.Interfaces;

namespace WebCore.Controllers
{
	public class BlogController : Controller
	{
		public IBlogNewsService blogNewsService;

		public BlogController(IBlogNewsService blogNewsService)
		{
			this.blogNewsService = blogNewsService;
		}

		public IActionResult Blog()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddElement(BlogNews blog)
		{
			if (HttpContext.User.Identity != null && HttpContext.User.Identity.Name != null)
			{
				await blogNewsService.AddElementBlogNews(blog, HttpContext.User.Identity.Name);
			}	
            return RedirectToAction("Index","Home");
        }
    }
}
