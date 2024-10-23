using CinemaAPI.Data;
using CinemaAPI.Models;
using CinemaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Repositories
{
    public class ExibicaoRepository : IExibicaoRepository
    {
        private readonly CinemaContext _context;

        public ExibicaoRepository(CinemaContext context)
        {
            _context = context;
        }

        public async Task<List<Exibicao>> GetAllExibicoesAsync()
        {
            return await _context.Exibicoes.ToListAsync();
        }

        public async Task<Exibicao> GetExibicaoByIdAsync(int id)
        {
            return await _context.Exibicoes.FindAsync(id);
        }

        public async Task CreateExibicaoAsync(Exibicao exibicao)
        {
            _context.Exibicoes.Add(exibicao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateExibicaoAsync(Exibicao exibicao)
        {
            _context.Exibicoes.Update(exibicao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExibicaoAsync(int id)
        {
            var exibicao = await GetExibicaoByIdAsync(id);
            if (exibicao != null)
            {
                _context.Exibicoes.Remove(exibicao);
                await _context.SaveChangesAsync();
            }
        }
    }
}