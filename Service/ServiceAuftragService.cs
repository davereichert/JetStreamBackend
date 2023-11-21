using JetStreamBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace JetStreamBackend.Service
{
    public class ServiceAuftragService
    {
        private readonly SkiServiceContext _context;

        public ServiceAuftragService(SkiServiceContext context)
        {
            _context = context;
        }

        public async Task<ServiceAuftrag> CreateServiceAuftragAsync(ServiceAuftrag auftrag)
        {
            _context.ServiceAuftraege.Add(auftrag);
            await _context.SaveChangesAsync();
            return auftrag;
        }
        public async Task<List<ServiceAuftrag>> GetAuftraegeAsync()
        {
            return await _context.ServiceAuftraege.ToListAsync();
        }

        public async Task DeleteAuftragAsync(int id)
        {
            var auftrag = await _context.ServiceAuftraege.FindAsync(id);
            if (auftrag == null)
            {
                throw new Exception("Auftrag nicht gefunden.");
            }

            _context.ServiceAuftraege.Remove(auftrag);
            await _context.SaveChangesAsync();
        }

    }

}
