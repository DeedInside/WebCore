using Microsoft.AspNetCore.Mvc;
using WebCore.Domain.Models;
using WebCore.Service.Interfaces;

namespace WebCore.Controllers
{
	public class BlogController : Controller
	{
		public IBlogNewsService blogNewsService;
        private readonly IWebHostEnvironment _appEnvironment;


		public BlogController(IBlogNewsService blogNewsService, IWebHostEnvironment appEnvironment)
		{
			this.blogNewsService = blogNewsService;
			_appEnvironment = appEnvironment;
		}

		public IActionResult Blog()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddElement(BlogNews blog, IFormFile uploadedFile)
		{
			if (HttpContext.User.Identity != null && HttpContext.User.Identity.Name != null)
			{
				await blogNewsService.AddElementBlogNews(blog, HttpContext.User.Identity.Name, _appEnvironment.ContentRootPath, uploadedFile);
			}	
            return RedirectToAction("Index","Home");
        }
    }
}
