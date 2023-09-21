using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCore.Domain.Models
{
    public class Role
    {
        /// <summary>
        /// id role
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// name users
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// list users 
        /// </summary>
        public List<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}
