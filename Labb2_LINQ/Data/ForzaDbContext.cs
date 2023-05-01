using Microsoft.EntityFrameworkCore;
using Labb2_LINQ.Models;

namespace Labb2_LINQ.Data
{
    public class ForzaDbContext : DbContext
    {
        public ForzaDbContext(DbContextOptions<ForzaDbContext> options) 
            : base(options) 
        {

        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<SchoolConnection> SchoolConnections { get; set; }
    }
}
