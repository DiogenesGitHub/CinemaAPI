using CinemaAPI.Data;
using CinemaAPI.Models;
using CinemaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace CinemaAPI.Repositories
{
    public class SessaoRepository : ISessaoRepository
    {
        private readonly CinemaContext _context;

        public SessaoRepository(CinemaContext context)
        {
            _context = context;
        }

        public async Task<List<Sessao>> GetAllSessoesAsync()
        {
            return await _context.Sessoes.Include(s => s.Exibicao).ToListAsync();
        }

        public async Task<Sessao> GetSessaoByIdAsync(int id)
        {
            return await _context.Sessoes.Include(s => s.Exibicao).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task CreateSessaoAsync(Sessao sessao)
        {
            _context.Sessoes.Add(sessao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSessaoAsync(Sessao sessao)
        {
            _context.Sessoes.Update(sessao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSessaoAsync(int id)
        {
            var sessao = await GetSessaoByIdAsync(id);
            if (sessao != null)
            {
                _context.Sessoes.Remove(sessao);
                await _context.SaveChangesAsync();
            }
        }
    }
}