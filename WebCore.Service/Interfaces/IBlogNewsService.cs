using Microsoft.AspNetCore.Http;
using WebCore.Domain.Models;
using WebCore.Domain.Response;

namespace WebCore.Service.Interfaces
{
	public interface IBlogNewsService
	{
        Task<BaseResponse<IEnumerable<BlogNews>>> GetElemetBlogNews();
        Task<BaseResponse<bool>> AddElementBlogNews(BlogNews blogNews, string nameUser, string filePath, IFormFile uploadedFile);
    }
}
