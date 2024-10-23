using CinemaAPI.Models;
using CinemaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExibicoesController : ControllerBase
    {
        private readonly IExibicaoService _exibicaoService;

        public ExibicoesController(IExibicaoService exibicaoService)
        {
            _exibicaoService = exibicaoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Exibicao>>> GetAllExibicoes()
        {
            var exibicoes = await _exibicaoService.GetAllExibicoesAsync();
            return Ok(exibicoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exibicao>> GetExibicaoById(int id)
        {
            var exibicao = await _exibicaoService.GetExibicaoByIdAsync(id);
            if (exibicao == null)
            {
                return NotFound();
            }
            return Ok(exibicao);
        }

        [HttpPost]
        public async Task<ActionResult> CreateExibicao([FromBody] Exibicao exibicao)
        {
            await _exibicaoService.CreateExibicaoAsync(exibicao);
            return CreatedAtAction(nameof(GetExibicaoById), new { id = exibicao.Id }, exibicao);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateExibicao(int id, [FromBody] Exibicao exibicao)
        {
            if (id != exibicao.Id)
            {
                return BadRequest();
            }

            await _exibicaoService.UpdateExibicaoAsync(exibicao);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExibicao(int id)
        {
            await _exibicaoService.DeleteExibicaoAsync(id);
            return NoContent();
        }
    }
}