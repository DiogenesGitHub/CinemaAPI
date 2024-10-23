using CinemaAPI.Data;
using CinemaAPI.Models;
using CinemaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaAPI.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly CinemaContext _context;

        public FilmeRepository(CinemaContext context)
        {
            _context = context;
        }

        public async Task<List<Filme>> GetAllFilmesAsync()
        {
            return await _context.Filmes.ToListAsync();
        }

        public async Task<Filme> GetFilmeByIdAsync(int id)
        {
            return await _context.Filmes.FindAsync(id);
        }

        public async Task CreateFilmeAsync(Filme filme)
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFilmeAsync(Filme filme)
        {
            _context.Filmes.Update(filme);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFilmeAsync(int id)
        {
            var filme = await GetFilmeByIdAsync(id);
            if (filme != null)
            {
                _context.Filmes.Remove(filme);
                await _context.SaveChangesAsync();
            }
        }
    }
}