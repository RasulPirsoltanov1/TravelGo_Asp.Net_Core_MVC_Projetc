using Microsoft.EntityFrameworkCore;

namespace SignalRApi.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Visitor> Visitors { get; set; }

    }
}
