using Microsoft.EntityFrameworkCore;

namespace CoreApp.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> context) : base(context)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
