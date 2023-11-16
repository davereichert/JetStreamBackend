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
    }

}
