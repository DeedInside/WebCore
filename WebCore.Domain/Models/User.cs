using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCore.Domain.Models
{
    public class User
    {
        public User(int id, string? name, string? password, string? email,
                    DateTime age, string? phoneNumber, string? imageUrl,
                    Role? role, int roleId)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            Age = age;
            PhoneNumber = phoneNumber;
            ImageUrl = imageUrl;
            Role = role;
            RoleId = roleId;
        }
        public User()
        {
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public DateTime Age { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ImageUrl { get; set; }
        public Role? Role { get; set; }
        public int RoleId { get; set; }
    }
}
