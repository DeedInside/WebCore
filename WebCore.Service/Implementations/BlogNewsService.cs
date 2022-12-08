using WebCore.DALL.Interfaces;
using WebCore.Domain.Models;
using WebCore.Domain.Response;
using WebCore.Service.Interfaces;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace WebCore.Service.Implementations
{
	public class BlogNewsService : IBlogNewsService
	{
        private readonly IBlogNewsRepository? blogNewsRepository;
        private readonly IUserRepository userRepository;
        public BlogNewsService(IBlogNewsRepository? blogNewsRepository, IUserRepository userRepository)
        {
            this.blogNewsRepository = blogNewsRepository;
            this.userRepository = userRepository;
        }

        public async Task<BaseResponse<bool>> AddElementBlogNews(BlogNews blogNews, string nameUser, string filePath, IFormFile uploadedFile)
        {
            var baseResponse = new BaseResponse<bool>();


            if (uploadedFile == null)
            {
                blogNews.Url_image = "/image/Undefine.jpeg";
            }
            else
            {
                blogNews.Url_image = "/image/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(filePath + "/wwwroot/" + blogNews.Url_image, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
            }
            if (blogNews.Time == null)
            {
                blogNews.Time = DateTime.Now;
            }
            if (blogNews.Text_Content != null && blogNews.Categori != null)
            {
                BlogNews blog = new BlogNews()
                {
                    Categori = blogNews.Categori,
                    Text_Content = blogNews.Text_Content,
                    Url_image = blogNews.Url_image,
                    Time = blogNews.Time,
                    User = await userRepository.GetName(nameUser)
                };
                var ret = await blogNewsRepository.Create(blog);
                baseResponse.Data = ret;
                baseResponse.Description = "am not eby kak the work";
            }


            return baseResponse;
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
