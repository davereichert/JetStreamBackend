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

        public async Task<ServiceAuftrag> GetAuftraegAsync(int id)
        {
            var auftrag = await _context.ServiceAuftraege.FindAsync(id);
            return auftrag;
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

        public async Task<ServiceAuftrag> UpdateAuftragAsync(int id, ServiceAuftrag auftrag)
        {
            var vorhandenerAuftrag = await _context.ServiceAuftraege.FindAsync(id);
            if (vorhandenerAuftrag == null)
            {
                throw new Exception("Auftrag nicht gefunden.");
            }

            vorhandenerAuftrag.KundenName = auftrag.KundenName;
            vorhandenerAuftrag.Email = auftrag.Email;
            vorhandenerAuftrag.Phone = auftrag.Phone;
            vorhandenerAuftrag.Priority = auftrag.Priority;
            vorhandenerAuftrag.Service = auftrag.Service;
            vorhandenerAuftrag.SendDate = auftrag.SendDate;

            await _context.SaveChangesAsync();
            return vorhandenerAuftrag;
        }

    }

}
