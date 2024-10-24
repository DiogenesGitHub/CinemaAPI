using CinemaAPI.Models;
using CinemaAPI.Repositories.Interfaces;
using CinemaAPI.Services;
using Moq;


namespace CinemaAPITests.Services
{
    public class SalaServiceTests
    {
        private readonly Mock<ISalaRepository> _salaRepositoryMock;
        private readonly SalaService _salaService;

        public SalaServiceTests()
        {
            _salaRepositoryMock = new Mock<ISalaRepository>();
            _salaService = new SalaService(_salaRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllSalasAsync_ReturnsListOfSalas()
        {
            // Arrange
            var salas = new List<Sala>
            {
                new Sala { Id = 1, Nome = "Sala 1", Capacidade = 100 },
                new Sala { Id = 2, Nome = "Sala 2", Capacidade = 150 }
            };
            _salaRepositoryMock.Setup(repo => repo.GetAllSalasAsync()).ReturnsAsync(salas);

            // Act
            var result = await _salaService.GetAllSalasAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetSalaByIdAsync_ReturnsSala()
        {
            // Arrange
            var sala = new Sala { Id = 1, Nome = "Sala 1", Capacidade = 100 };
            _salaRepositoryMock.Setup(repo => repo.GetSalaByIdAsync(1)).ReturnsAsync(sala);

            // Act
            var result = await _salaService.GetSalaByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Sala 1", result.Nome);
            Assert.Equal(100, result.Capacidade);
        }

        [Fact]
        public async Task CreateSalaAsync_CallsRepositoryCreateMethod()
        {
            // Arrange
            var sala = new Sala { Id = 1, Nome = "Sala 1", Capacidade = 100 };

            // Act
            await _salaService.CreateSalaAsync(sala);

            // Assert
            _salaRepositoryMock.Verify(repo => repo.CreateSalaAsync(sala), Times.Once);
        }

        [Fact]
        public async Task UpdateSalaAsync_CallsRepositoryUpdateMethod()
        {
            // Arrange
            var sala = new Sala { Id = 1, Nome = "Sala 1", Capacidade = 100 };

            // Act
            await _salaService.UpdateSalaAsync(sala);

            // Assert
            _salaRepositoryMock.Verify(repo => repo.UpdateSalaAsync(sala), Times.Once);
        }

        [Fact]
        public async Task DeleteSalaAsync_CallsRepositoryDeleteMethod()
        {
            // Arrange
            int id = 1;

            // Act
            await _salaService.DeleteSalaAsync(id);

            // Assert
            _salaRepositoryMock.Verify(repo => repo.DeleteSalaAsync(id), Times.Once);
        }
    }
}
