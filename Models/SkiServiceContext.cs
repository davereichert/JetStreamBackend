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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Mitarbeiter>()
                .HasIndex(m => m.Benutzername)
                .IsUnique();

            // Konvertieren Sie die Rolle (wenn es ein Enum ist) in einen String
            modelBuilder
                .Entity<Mitarbeiter>()
                .Property(m => m.Rolle)
                .HasConversion<string>();

            modelBuilder.Entity<Mitarbeiter>().HasData(
            new Mitarbeiter
            {
                Id = 1,
                Name = "Max Mustermann",
                Benutzername = "maxmuster",
                Passwort = "passwort123",
                Email = "max@example.com",
                Telefonnummer = "0123456789",
                Rolle = "Administrator",
                IsActive = true,
                Erstellungsdatum = DateTime.Now,
                LetzteAnmeldung = DateTime.Now
            },

            new Mitarbeiter
            {
                Id = 2,
                Name = "arda Mustermann",
                Benutzername = "arda",
                Passwort = "passwort123",
                Email = "max@example.com",
                Telefonnummer = "0123456789",
                Rolle = "Mitarbeiter",
                IsActive = true,
                Erstellungsdatum = DateTime.Now,
                LetzteAnmeldung = DateTime.Now

            },

            new Mitarbeiter
            {
                Id = 3,
                Name = "Tom Schmitz",
                Benutzername = "tom",
                Passwort = "passwort123",
                Email = "tom@example.com",
                Telefonnummer = "0123456791",
                Rolle = "Mitarbeiter",
                IsActive = true,
                Erstellungsdatum = DateTime.Now,
                LetzteAnmeldung = DateTime.Now
            },
            new Mitarbeiter
            {
                Id = 4,
                Name = "Anna Schmidt",
                Benutzername = "anna",
                Passwort = "passwort123",
                Email = "anna@example.com",
                Telefonnummer = "0123456792",
                Rolle = "Mitarbeiter",
                IsActive = true,
                Erstellungsdatum = DateTime.Now,
                LetzteAnmeldung = DateTime.Now
            },
            new Mitarbeiter
            {
                Id = 5,
                Name = "Jan Bauer",
                Benutzername = "jan",
                Passwort = "passwort123",
                Email = "jan@example.com",
                Telefonnummer = "0123456793",
                Rolle = "Mitarbeiter",
                IsActive = true,
                Erstellungsdatum = DateTime.Now,
                LetzteAnmeldung = DateTime.Now
            },
            new Mitarbeiter
            {
                Id = 6,
                Name = "Sara Koch",
                Benutzername = "sara",
                Passwort = "passwort123",
                Email = "sara@example.com",
                Telefonnummer = "0123456794",
                Rolle = "Mitarbeiter",
                IsActive = true,
                Erstellungsdatum = DateTime.Now,
                LetzteAnmeldung = DateTime.Now
            },
            new Mitarbeiter
            {
                Id = 7,
                Name = "Markus Weber",
                Benutzername = "markus",
                Passwort = "passwort123",
                Email = "markus@example.com",
                Telefonnummer = "0123456795",
                Rolle = "Mitarbeiter",
                IsActive = true,
                Erstellungsdatum = DateTime.Now,
                LetzteAnmeldung = DateTime.Now
            },
            new Mitarbeiter
            {
                Id = 8,
                Name = "Julia Lange",
                Benutzername = "julia",
                Passwort = "passwort123",
                Email = "julia@example.com",
                Telefonnummer = "0123456796",
                Rolle = "Mitarbeiter",
                IsActive = true,
                Erstellungsdatum = DateTime.Now,
                LetzteAnmeldung = DateTime.Now
            },
            new Mitarbeiter
            {
                Id = 9,
                Name = "Felix Klein",
                Benutzername = "felix",
                Passwort = "passwort123",
                Email = "felix@example.com",
                Telefonnummer = "0123456797",
                Rolle = "Mitarbeiter",
                IsActive = true,
                Erstellungsdatum = DateTime.Now,
                LetzteAnmeldung = DateTime.Now
            },
            new Mitarbeiter
            {
                Id = 10,
                Name = "Sophie Groß",
                Benutzername = "sophie",
                Passwort = "passwort123",
                Email = "sophie@example.com",
                Telefonnummer = "0123456798",
                Rolle = "Mitarbeiter",
                IsActive = true,
                Erstellungsdatum = DateTime.Now,
                LetzteAnmeldung = DateTime.Now
            }
            );

        }
    }
}
