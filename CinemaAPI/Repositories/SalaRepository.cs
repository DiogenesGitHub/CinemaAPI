using CinemaAPI.Data;
using CinemaAPI.Models;
using CinemaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Repositories
{
    public class SalaRepository : ISalaRepository
    {
        private readonly CinemaContext _context;

        public SalaRepository(CinemaContext context)
        {
            _context = context;
        }

        public async Task<List<Sala>> GetAllSalasAsync()
        {
            return await _context.Salas.ToListAsync();
        }

        public async Task<Sala> GetSalaByIdAsync(int id)
        {
            return await _context.Salas.FindAsync(id);
        }

        public async Task CreateSalaAsync(Sala sala)
        {
            _context.Salas.Add(sala);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSalaAsync(Sala sala)
        {
            _context.Salas.Update(sala);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSalaAsync(int id)
        {
            var sala = await GetSalaByIdAsync(id);
            if (sala != null)
            {
                _context.Salas.Remove(sala);
                await _context.SaveChangesAsync();
            }
        }
    }
}