using Microsoft.EntityFrameworkCore;
using WebCore.Domain.Models;

namespace WebCore.DALL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User>? UserSQL { get; set; }
        public DbSet<BlogNews> BlogNewsSQL { get; set; }
        public DbSet<Role> RoleSQL { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
