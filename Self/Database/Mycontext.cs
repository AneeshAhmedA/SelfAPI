using Microsoft.EntityFrameworkCore;
using Self.Entity;

namespace Self.Database
{
    public class MyContext : DbContext
    {
        private readonly IConfiguration configuration;
  
        public MyContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public DbSet<User>? Users1 { get; set; }

        public DbSet<Train>? Trains1 { get; set; }

        public DbSet<Conference>? Conferences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
