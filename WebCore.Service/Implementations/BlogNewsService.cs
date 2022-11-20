using WebCore.DALL.Interfaces;
using WebCore.DALL.Repositories;
using WebCore.Domain.Models;
using WebCore.Domain.Response;
using WebCore.Service.Interfaces;

namespace WebCore.Service.Implementations
{
	public class BlogNewsService : IBlogNewsService
	{
        private readonly IBlogNewsRepository? blogNewsRepository;
        public BlogNewsService(IBlogNewsRepository? blogNewsRepository)
        {
            this.blogNewsRepository = blogNewsRepository;
        }

        public async Task<BaseResponse<IEnumerable<BlogNews>>> GetElemetBlogNews()
		{
            var baseResponse = new BaseResponse<IEnumerable<BlogNews>>();
            var blog = await blogNewsRepository.GetAll();

            if (blog.Count > 0)
            {
                baseResponse.Data = blog;
                baseResponse.Description = "Выгрузка прошла успешно";
                return baseResponse;
            }
            else
            {
                baseResponse.Description = "Всё пошло по пиздец, переделывай";
            }

            return baseResponse;
        }
	}
}
