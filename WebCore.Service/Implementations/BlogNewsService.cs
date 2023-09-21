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
        private readonly IUserRepository? userRepository;
        public BlogNewsService(IBlogNewsRepository? blogNewsRepository, IUserRepository? userRepository)
        {
            this.blogNewsRepository = blogNewsRepository;
            this.userRepository = userRepository;
        }
        /// <summary>
        /// adds record in DB
        /// </summary>
        /// <param name="blogNews"></param>
        /// <param name="nameUser">name user</param>
        /// <param name="filePath">path image</param>
        /// <param name="uploadedFile">image load</param>
        /// <returns></returns>
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
                baseResponse.Description = "description";
            }


            return baseResponse;
        }
        /// <summary>
        /// delits record from a blog by id 
        /// </summary>
        /// <param name="id">id record</param>
        /// <returns></returns>
        public async Task<BaseResponse<bool>> DelitElementById(int id)
        {
            var retur = new BaseResponse<bool>();
            bool rez = await blogNewsRepository.Delete(id);
            if (rez)
            {
                retur.Data = true;
                retur.Description = "Элемент удачен усмешно";
                return retur;
            }
            else
            {
                retur.Data = false;
                retur.Description = "Ошибка удаления элемента";
                return retur;
            }
        }
        /// <summary>
        /// return all data from DB
        /// </summary>
        /// <returns></returns>
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
                baseResponse.Description = "УПС......не вернул";
            }

            return baseResponse;
        }
	}
}
