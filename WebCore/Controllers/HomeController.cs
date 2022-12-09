using Microsoft.AspNetCore.Mvc;
using WebCore.Service.Implementations;
using WebCore.Service.Interfaces;

namespace WebCore.Controllers
{
    public class HomeController : Controller
    {
        public IUserService UserService;
        public IBlogNewsService BlogNewsService;

        public HomeController(IUserService userService, IBlogNewsService blogNewsService)
        {
            UserService = userService;
            BlogNewsService = blogNewsService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await BlogNewsService.GetElemetBlogNews();
            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> DeliteBlog(int id)
        {
            var response = await BlogNewsService.DelitElementById(id);
            return RedirectToAction("Index");
        }
    }
}
