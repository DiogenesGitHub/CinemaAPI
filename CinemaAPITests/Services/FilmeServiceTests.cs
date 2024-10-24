using CinemaAPI.Models;
using CinemaAPI.Repositories.Interfaces;
using CinemaAPI.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAPITests.Services
{
    public class FilmeServiceTests
    {
        private readonly Mock<IFilmeRepository> _filmeRepositoryMock;
        private readonly FilmeService _filmeService;

        public FilmeServiceTests()
        {
            _filmeRepositoryMock = new Mock<IFilmeRepository>();
            _filmeService = new FilmeService(_filmeRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllFilmesAsync_ReturnsListOfFilmes()
        {
            // Arrange
            var filmes = new List<Filme>
            {
                new Filme { Id = 1, Titulo = "Filme 1", Genero = "Ação", Duracao = 120, AnoLancamento = 2021 },
                new Filme { Id = 2, Titulo = "Filme 2", Genero = "Comédia", Duracao = 90, AnoLancamento = 2022 }
            };
            _filmeRepositoryMock.Setup(repo => repo.GetAllFilmesAsync()).ReturnsAsync(filmes);

            // Act
            var result = await _filmeService.GetAllFilmesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetFilmeByIdAsync_ReturnsFilme()
        {
            // Arrange
            var filme = new Filme { Id = 1, Titulo = "Filme 1", Genero = "Ação", Duracao = 120, AnoLancamento = 2021 };
            _filmeRepositoryMock.Setup(repo => repo.GetFilmeByIdAsync(1)).ReturnsAsync(filme);

            // Act
            var result = await _filmeService.GetFilmeByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Filme 1", result.Titulo);
            Assert.Equal(2021, result.AnoLancamento);
        }

        [Fact]
        public async Task CreateFilmeAsync_CallsRepositoryCreateMethod()
        {
            // Arrange
            var filme = new Filme { Id = 1, Titulo = "Filme 1", Genero = "Ação", Duracao = 120, AnoLancamento = 2021 };

            // Act
            await _filmeService.CreateFilmeAsync(filme);

            // Assert
            _filmeRepositoryMock.Verify(repo => repo.CreateFilmeAsync(filme), Times.Once);
        }

        [Fact]
        public async Task UpdateFilmeAsync_CallsRepositoryUpdateMethod()
        {
            // Arrange
            var filme = new Filme { Id = 1, Titulo = "Filme 1", Genero = "Ação", Duracao = 120, AnoLancamento = 2021 };

            // Act
            await _filmeService.UpdateFilmeAsync(filme);

            // Assert
            _filmeRepositoryMock.Verify(repo => repo.UpdateFilmeAsync(filme), Times.Once);
        }

        [Fact]
        public async Task DeleteFilmeAsync_CallsRepositoryDeleteMethod()
        {
            // Arrange
            int id = 1;

            // Act
            await _filmeService.DeleteFilmeAsync(id);

            // Assert
            _filmeRepositoryMock.Verify(repo => repo.DeleteFilmeAsync(id), Times.Once);
        }
    }
}
