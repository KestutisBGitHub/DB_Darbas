using Microsoft.EntityFrameworkCore;

namespace DB_Darbas
{
    public class JwtDemoDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Location> Location { get; set; }

        public JwtDemoDbContext(DbContextOptions<JwtDemoDbContext> options) : base(options)
        {

        }
    }
}
