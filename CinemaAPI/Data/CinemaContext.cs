using CinemaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Data
{
    public class CinemaContext : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Exibicao> Exibicoes { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }

        // Construtor que aceita uma string de conexão
        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filme>()
                .ToTable("Filmes")
                .HasKey(f => f.Id);

            modelBuilder.Entity<Sala>()
                .ToTable("Salas")
                .HasKey(s => s.Id);

            modelBuilder.Entity<Exibicao>()
                .ToTable("Exibicoes")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Exibicao>()
                .HasOne(e => e.Filme)
                .WithMany(f => f.Exibicoes)
                .HasForeignKey(e => e.FilmeId);

            modelBuilder.Entity<Exibicao>()
                .HasOne(e => e.Sala)
                .WithMany(s => s.Exibicoes)
                .HasForeignKey(e => e.SalaId);

            modelBuilder.Entity<Sessao>()
                .ToTable("Sessoes")
                .HasKey(ses => ses.Id);

            modelBuilder.Entity<Sessao>()
                .HasOne(ses => ses.Exibicao)
                .WithMany(e => e.Sessoes)
                .HasForeignKey(ses => ses.ExibicaoId);
        }
    }
}