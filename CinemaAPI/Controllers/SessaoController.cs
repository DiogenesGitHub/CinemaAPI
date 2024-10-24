using CinemaAPI.Models;
using CinemaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessoesController : ControllerBase
    {
        private readonly ISessaoService _sessaoService;

        public SessoesController(ISessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sessao>>> GetAllSessoes()
        {
            var sessoes = await _sessaoService.GetAllSessoesAsync();
            return Ok(sessoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sessao>> GetSessaoById(int id)
        {
            var sessao = await _sessaoService.GetSessaoByIdAsync(id);
            if (sessao == null)
            {
                return NotFound();
            }
            return Ok(sessao);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSessao([FromBody] Sessao sessao)
        {
            await _sessaoService.CreateSessaoAsync(sessao);
            return CreatedAtAction(nameof(GetSessaoById), new { id = sessao.Id }, sessao);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSessao(int id, [FromBody] Sessao sessao)
        {
            if (id != sessao.Id)
            {
                return BadRequest();
            }

            await _sessaoService.UpdateSessaoAsync(sessao);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSessao(int id)
        {
            await _sessaoService.DeleteSessaoAsync(id);
            return NoContent();
        }
    }
}