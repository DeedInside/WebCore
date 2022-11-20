using WebCore.Domain.Models;
using WebCore.Domain.Response;

namespace WebCore.Service.Interfaces
{
	public interface IBlogNewsService
	{
        Task<BaseResponse<IEnumerable<BlogNews>>> GetElemetBlogNews();
    }
}
