using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using JetStreamBackend.Models;
using JetStreamBackend.Service;


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

            [HttpPut("{benutzername}/lastLogin")]
            public async Task<IActionResult> UpdateLastLogin(string benutzername, [FromBody] LastLoginModel model)
            {
                try
                {
                    var mitarbeiter = await _mitarbeiterService.UpdateLastLoginAsync(benutzername, model.LastLogin);
                    if (mitarbeiter == null)
                    {
                        
                        return NotFound();
                    }
                    
                    return Ok(mitarbeiter);
                }
                catch (Exception ex)
                {
                    return BadRequest("Fehler beim Aktualisieren des letzten Logins: " + ex.Message);
                }
            }

    }
}


