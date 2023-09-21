using Microsoft.EntityFrameworkCore;
using WebCore.Domain.Models;

namespace WebCore.DALL
{
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// data base users
        /// </summary>
        public DbSet<User>? UserSQL { get; set; }
        /// <summary>
        /// data base record blogs
        /// </summary>
        public DbSet<BlogNews> BlogNewsSQL { get; set; }
        /// <summary>
        /// data base role users
        /// </summary>
        public DbSet<Role> RoleSQL { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
