using JetStreamBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace JetStreamBackend.Service
{
    public class MitarbeiterService
    {
        private readonly SkiServiceContext _context;

        public MitarbeiterService(SkiServiceContext context)
        {
            _context = context;
        }

        public async Task CreateMitarbeiterAsync(Mitarbeiter mitarbeiter)
        {
            try
            {
                _context.Mitarbeiter.Add(mitarbeiter);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler beim Hinzufügen des Mitarbeiters: " + ex.Message);
            }
        }
        public string GetRolleVonBenutzer(string benutzername)
        {
            // Hier den Code zum Abrufen der Rolle aus der Datenbank
            var mitarbeiter = _context.Mitarbeiter.FirstOrDefault(m => m.Benutzername == benutzername);
            return mitarbeiter?.Rolle;
        }

        public async Task<Mitarbeiter> UpdateLastLoginAsync(string benutzername, DateTime lastLogin)
        {
            var mitarbeiter = await _context.Mitarbeiter.FirstOrDefaultAsync(m => m.Benutzername == benutzername);
            if (mitarbeiter == null)
            {
                return null;
            }

            mitarbeiter.LetzteAnmeldung = lastLogin;
            await _context.SaveChangesAsync();

            return mitarbeiter;
        }

       



    }
}
