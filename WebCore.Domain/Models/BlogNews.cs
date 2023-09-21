using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCore.Domain.Models
{
	public class BlogNews
	{
        public BlogNews()
        {

        }
        public BlogNews(int id, string categori, string text_Content, string? url_image, DateTime? time, User user, int userId)
        {
            Id = id;
            Categori = categori;
            Text_Content = text_Content;
            Url_image = url_image;
            Time = time;
            User = user;
            UserId = userId;
        }
        /// <summary>
        /// id record
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// categori record
        /// </summary>
        public string Categori { get; set; }
        /// <summary>
        /// Description record
        /// </summary>
        public string Text_Content { get; set; }
        /// <summary>
        /// url image the post
        /// </summary>
        public string? Url_image { get; set; }
        /// <summary>
        /// date creating post
        /// </summary>
        public DateTime? Time { get; set; }
        /// <summary>
        /// The user who created the post 
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// id user created the post
        /// </summary>
        public int UserId { get; set; }
    }
}
