using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;

namespace CoreApp.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {


        }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
