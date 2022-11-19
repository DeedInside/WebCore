using Microsoft.EntityFrameworkCore;
using WebCore.Domain.Models;

namespace WebCore.DALL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User>? UserSQL { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
