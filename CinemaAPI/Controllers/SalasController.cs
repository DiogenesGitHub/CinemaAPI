using CinemaAPI.Models;
using CinemaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalasController : ControllerBase
    {
        private readonly ISalaService _salaService;

        public SalasController(ISalaService salaService)
        {
            _salaService = salaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sala>>> GetAllSalas()
        {
            var salas = await _salaService.GetAllSalasAsync();
            return Ok(salas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sala>> GetSalaById(int id)
        {
            var sala = await _salaService.GetSalaByIdAsync(id);
            if (sala == null)
            {
                return NotFound();
            }
            return Ok(sala);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSala([FromBody] Sala sala)
        {
            await _salaService.CreateSalaAsync(sala);
            return CreatedAtAction(nameof(GetSalaById), new { id = sala.Id }, sala);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSala(int id, [FromBody] Sala sala)
        {
            if (id != sala.Id)
            {
                return BadRequest();
            }

            await _salaService.UpdateSalaAsync(sala);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSala(int id)
        {
            await _salaService.DeleteSalaAsync(id);
            return NoContent();
        }
    }
}