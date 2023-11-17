using JetStreamBackend.Models;
using JetStreamBackend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JetStreamBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceAuftragController : ControllerBase
    {
        private readonly ServiceAuftragService _serviceAuftragService;

        public ServiceAuftragController(ServiceAuftragService serviceAuftragService)
        {
            _serviceAuftragService = serviceAuftragService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ServiceAuftrag auftrag)
        {
            var erstellterAuftrag = await _serviceAuftragService.CreateServiceAuftragAsync(auftrag);
            return CreatedAtAction(nameof(Post), new { id = erstellterAuftrag.Id }, erstellterAuftrag);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ServiceAuftrag>>> GetAuftraege()
        {
            return await _serviceAuftragService.GetAuftraegeAsync();
        }
    }

}
