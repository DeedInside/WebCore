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

        public int Id { get; set; }
        public string Categori { get; set; }
        public string Text_Content { get; set; }
        public string? Url_image { get; set; }
        public DateTime? Time { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
