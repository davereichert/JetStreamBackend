using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using JetStreamBackend.Models;
using JetStreamBackend.Service;
using global::JetStreamBackend.Models;
using global::JetStreamBackend.Service;

namespace JetStreamBackend.Controllers
{
        [ApiController]
        [Route("mitarbeiter")]
        public class MitarbeiterController : ControllerBase
        {
            private readonly MitarbeiterService _mitarbeiterService;

            public MitarbeiterController(MitarbeiterService mitarbeiterService)
            {
                _mitarbeiterService = mitarbeiterService;
            }

            [HttpPost]
            public async Task<IActionResult> Post([FromBody] Mitarbeiter mitarbeiter)
            {
                try
                {
                    await _mitarbeiterService.CreateMitarbeiterAsync(mitarbeiter);
                    return Ok("Mitarbeiter wurde erfolgreich hinzugefügt.");
                }
                catch (Exception ex)
                {
                    return BadRequest("Fehler beim Hinzufügen des Mitarbeiters: " + ex.Message);
                }
            }

            [HttpGet("rolle/{benutzername}")]
            public ActionResult<string> GetRolle(string benutzername)
            {
                var rolle = _mitarbeiterService.GetRolleVonBenutzer(benutzername);
                if (rolle == null)
                {
                    return NotFound();
                }
                return Ok(rolle);
            }
        }
 }


