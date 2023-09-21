using Microsoft.AspNetCore.Http;
using WebCore.Domain.Models;
using WebCore.Domain.Response;

namespace WebCore.Service.Interfaces
{
	public interface IBlogNewsService
	{
        /// <summary>
        /// return all data from DB
        /// </summary>
        /// <returns></returns>
        Task<BaseResponse<IEnumerable<BlogNews>>> GetElemetBlogNews();
        /// <summary>
        /// adds record in DB
        /// </summary>
        /// <returns></returns>
        Task<BaseResponse<bool>> AddElementBlogNews(BlogNews blogNews, string nameUser, string filePath, IFormFile uploadedFile);
        /// <summary>
        /// delits record from a blog by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BaseResponse<bool>> DelitElementById(int id);
    }
}
