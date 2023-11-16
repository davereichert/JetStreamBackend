using Microsoft.EntityFrameworkCore;

namespace JetStreamBackend.Models
{
    public class SkiServiceContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public SkiServiceContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<ServiceAuftrag> ServiceAuftraege { get; set; }
        public DbSet<Mitarbeiter> Mitarbeiter { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
