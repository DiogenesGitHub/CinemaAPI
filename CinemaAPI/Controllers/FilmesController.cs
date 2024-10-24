using CinemaAPI.Models;
using CinemaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmeService _filmeService;

        public FilmesController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Filme>>> GetAllFilmes()
        {
            var filmes = await _filmeService.GetAllFilmesAsync();
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> GetFilmeById(int id)
        {
            var filme = await _filmeService.GetFilmeByIdAsync(id);
            if (filme == null)
            {
                return NotFound();
            }
            return Ok(filme);
        }

        [HttpPost]
        public async Task<ActionResult> CreateFilme([FromBody] Filme filme)
        {
            await _filmeService.CreateFilmeAsync(filme);
            return CreatedAtAction(nameof(GetFilmeById), new { id = filme.Id }, filme);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFilme(int id, [FromBody] Filme filme)
        {
            if (id != filme.Id)
            {
                return BadRequest();
            }

            await _filmeService.UpdateFilmeAsync(filme);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFilme(int id)
        {
            await _filmeService.DeleteFilmeAsync(id);
            return NoContent();
        }
    }
}