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
    public class ExibicaoServiceTests
    {
        private readonly Mock<IExibicaoRepository> _exibicaoRepositoryMock;
        private readonly ExibicaoService _exibicaoService;

        public ExibicaoServiceTests()
        {
            _exibicaoRepositoryMock = new Mock<IExibicaoRepository>();
            _exibicaoService = new ExibicaoService(_exibicaoRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllExibicoesAsync_ReturnsListOfExibicoes()
        {
            // Arrange
            var exibicoes = new List<Exibicao>
            {
                new Exibicao { Id = 1, FilmeId = 1, SalaId = 1, DataExibicao = DateTime.Now },
                new Exibicao { Id = 2, FilmeId = 2, SalaId = 2, DataExibicao = DateTime.Now.AddDays(1) }
            };
            _exibicaoRepositoryMock.Setup(repo => repo.GetAllExibicoesAsync()).ReturnsAsync(exibicoes);

            // Act
            var result = await _exibicaoService.GetAllExibicoesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetExibicaoByIdAsync_ReturnsExibicao()
        {
            // Arrange
            var exibicao = new Exibicao { Id = 1, FilmeId = 1, SalaId = 1, DataExibicao = DateTime.Now };
            _exibicaoRepositoryMock.Setup(repo => repo.GetExibicaoByIdAsync(1)).ReturnsAsync(exibicao);

            // Act
            var result = await _exibicaoService.GetExibicaoByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(1, result.FilmeId);
            Assert.Equal(1, result.SalaId);
        }

        [Fact]
        public async Task CreateExibicaoAsync_CallsRepositoryCreateMethod()
        {
            // Arrange
            var exibicao = new Exibicao { Id = 1, FilmeId = 1, SalaId = 1, DataExibicao = DateTime.Now };

            // Act
            await _exibicaoService.CreateExibicaoAsync(exibicao);

            // Assert
            _exibicaoRepositoryMock.Verify(repo => repo.CreateExibicaoAsync(exibicao), Times.Once);
        }

        [Fact]
        public async Task UpdateExibicaoAsync_CallsRepositoryUpdateMethod()
        {
            // Arrange
            var exibicao = new Exibicao { Id = 1, FilmeId = 1, SalaId = 1, DataExibicao = DateTime.Now };

            // Act
            await _exibicaoService.UpdateExibicaoAsync(exibicao);

            // Assert
            _exibicaoRepositoryMock.Verify(repo => repo.UpdateExibicaoAsync(exibicao), Times.Once);
        }

        [Fact]
        public async Task DeleteExibicaoAsync_CallsRepositoryDeleteMethod()
        {
            // Arrange
            int id = 1;

            // Act
            await _exibicaoService.DeleteExibicaoAsync(id);

            // Assert
            _exibicaoRepositoryMock.Verify(repo => repo.DeleteExibicaoAsync(id), Times.Once);
        }
    }
}
