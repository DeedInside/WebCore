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
        /// <summary>
        /// id user
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// name user
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// password user
        /// </summary>
        public string? Password { get; set; }
        /// <summary>
        /// e-mail user
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// user's date of birth 
        /// </summary>
        public DateTime Age { get; set; }
        /// <summary>
        /// phone number
        /// </summary>
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// url of the user's image
        /// </summary>
        public string? ImageUrl { get; set; }
        /// <summary>
        /// Role user
        /// </summary>
        public Role? Role { get; set; }
        /// <summary>
        /// id role user
        /// </summary>
        public int RoleId { get; set; }
    }
}
