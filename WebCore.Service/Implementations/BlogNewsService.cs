using Azure;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net.NetworkInformation;
using WebCore.DALL.Interfaces;
using WebCore.DALL.Repositories;
using WebCore.Domain.Models;
using WebCore.Domain.Response;
using WebCore.Service.Interfaces;
using System.Security.Claims;

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

        public async Task<BaseResponse<bool>> AddElementBlogNews(BlogNews blogNews, string nameUser)
        {
            var baseResponse = new BaseResponse<bool>();

            //string path;
            //if (uploadedFile == null)
            //{
            //    path = "/image/BlackSqaut.png";
            //}
            //else
            //{
            //    // путь к папке Files
            //    path = "/image/" + uploadedFile.FileName;
            //    // сохраняем файл в папку Files в каталоге wwwroot
            //    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            //    {
            //        await uploadedFile.CopyToAsync(fileStream);
            //    }
            //}
            if (blogNews.Time == null)
            {
                blogNews.Time = DateTime.Now;
            }
            if(nameUser != null)
            {

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
