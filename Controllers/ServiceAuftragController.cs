﻿using JetStreamBackend.Models;
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
        private readonly ILogger<ServiceAuftragController> _logger; // Logger hinzufügen

        public ServiceAuftragController(ServiceAuftragService serviceAuftragService, ILogger<ServiceAuftragController> logger)
        {
            _serviceAuftragService = serviceAuftragService;
            _logger = logger; // Logger initialisieren
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ServiceAuftrag auftrag)
        {
            try
            {
                var erstellterAuftrag = await _serviceAuftragService.CreateServiceAuftragAsync(auftrag);
                _logger.LogInformation("ServiceAuftrag erstellt: {AuftragId}", erstellterAuftrag.Id); // Loggen des Erfolgs
                return CreatedAtAction(nameof(Post), new { id = erstellterAuftrag.Id }, erstellterAuftrag);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fehler beim Erstellen des ServiceAuftrags"); // Loggen von Fehlern
                return BadRequest("Ein Fehler ist aufgetreten");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceAuftrag>>> GetAuftraege()
        {
            try
            {
                var auftraege = await _serviceAuftragService.GetAuftraegeAsync();
                _logger.LogInformation("Kein Fehler beim Abrufen der Aufträge");
                return Ok(auftraege);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fehler beim Abrufen der Aufträge");
                return StatusCode(500, "Ein interner Fehler ist aufgetreten");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ServiceAuftrag>>> GetAuftraeg(int id)
        {
            try
            {
                var auftraeg = await _serviceAuftragService.GetAuftraegAsync(id);
                if (auftraeg == null)
                {
                    return NotFound("Kein Auftrag mit dieser id");
                }
                _logger.LogInformation("Kein Fehler beim Abrufen des Auftrages");
                return Ok(auftraeg);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fehler beim Abrufen der Aufträge");
                return StatusCode(500, "Ein interner Fehler ist aufgetreten");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuftrag(int id)
        {
            try
            {
                await _serviceAuftragService.DeleteAuftragAsync(id);
                _logger.LogInformation("Auftrag gelöscht: {AuftragId}", id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fehler beim Löschen des Auftrags: {AuftragId}", id);
                return BadRequest("Fehler beim Löschen des Auftrags: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, [FromBody] ServiceAuftrag auftrag)
        {
            try
            {
                var aktualisierterAuftrag = await _serviceAuftragService.UpdateAuftragAsync(id, auftrag);
                _logger.LogInformation("ServiceAuftrag aktualisiert: {AuftragId}", aktualisierterAuftrag.Id);
                return Ok(aktualisierterAuftrag);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fehler beim Aktualisieren des ServiceAuftrags: {AuftragId}", id);
                return BadRequest("Ein Fehler ist aufgetreten");
            }
        }

    }

}
