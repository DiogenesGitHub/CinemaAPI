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
    public class SessoesServiceTests
    {
        private readonly Mock<ISessaoRepository> _sessaoRepositoryMock;
        private readonly SessaoService _sessaoService;

        public SessoesServiceTests()
        {
            _sessaoRepositoryMock = new Mock<ISessaoRepository>();
            _sessaoService = new SessaoService(_sessaoRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllSessoesAsync_ReturnsListOfSessoes()
        {
            // Arrange
            var sessoes = new List<Sessao>
            {
                new Sessao { Id = 1, ExibicaoId = 1, DataHora = DateTime.Now },
                new Sessao { Id = 2, ExibicaoId = 2, DataHora = DateTime.Now.AddHours(2) }
            };
            _sessaoRepositoryMock.Setup(repo => repo.GetAllSessoesAsync()).ReturnsAsync(sessoes);

            // Act
            var result = await _sessaoService.GetAllSessoesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetSessaoByIdAsync_ReturnsSessao()
        {
            // Arrange
            var sessao = new Sessao { Id = 1, ExibicaoId = 1, DataHora = DateTime.Now };
            _sessaoRepositoryMock.Setup(repo => repo.GetSessaoByIdAsync(1)).ReturnsAsync(sessao);

            // Act
            var result = await _sessaoService.GetSessaoByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(1, result.ExibicaoId);
            Assert.Equal(sessao.DataHora, result.DataHora);
        }

        [Fact]
        public async Task CreateSessaoAsync_CallsRepositoryCreateMethod()
        {
            // Arrange
            var sessao = new Sessao { Id = 1, ExibicaoId = 1, DataHora = DateTime.Now };

            // Act
            await _sessaoService.CreateSessaoAsync(sessao);

            // Assert
            _sessaoRepositoryMock.Verify(repo => repo.CreateSessaoAsync(sessao), Times.Once);
        }

        [Fact]
        public async Task UpdateSessaoAsync_CallsRepositoryUpdateMethod()
        {
            // Arrange
            var sessao = new Sessao { Id = 1, ExibicaoId = 1, DataHora = DateTime.Now };

            // Act
            await _sessaoService.UpdateSessaoAsync(sessao);

            // Assert
            _sessaoRepositoryMock.Verify(repo => repo.UpdateSessaoAsync(sessao), Times.Once);
        }

        [Fact]
        public async Task DeleteSessaoAsync_CallsRepositoryDeleteMethod()
        {
            // Arrange
            int id = 1;

            // Act
            await _sessaoService.DeleteSessaoAsync(id);

            // Assert
            _sessaoRepositoryMock.Verify(repo => repo.DeleteSessaoAsync(id), Times.Once);
        }
    }
}
