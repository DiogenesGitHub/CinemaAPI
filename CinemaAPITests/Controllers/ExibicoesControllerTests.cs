using CinemaAPI.Controllers;
using CinemaAPI.Models;
using CinemaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CinemaAPITests.Controllers
{
    public class ExibicoesControllerTests
    {
        private readonly Mock<IExibicaoService> _exibicaoServiceMock;
        private readonly ExibicoesController _controller;

        public ExibicoesControllerTests()
        {
            _exibicaoServiceMock = new Mock<IExibicaoService>();
            _controller = new ExibicoesController(_exibicaoServiceMock.Object);
        }

        [Fact]
        public async Task GetAllExibicoes_ReturnsOkResult_WithListOfExibicoes()
        {
            // Arrange
            var exibicoes = new List<Exibicao> { new Exibicao { Id = 1 }, new Exibicao { Id = 2 } };
            _exibicaoServiceMock.Setup(service => service.GetAllExibicoesAsync()).ReturnsAsync(exibicoes);

            // Act
            var result = await _controller.GetAllExibicoes();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnExibicoes = Assert.IsType<List<Exibicao>>(okResult.Value);
            Assert.Equal(2, returnExibicoes.Count);
        }

        [Fact]
        public async Task GetExibicaoById_ReturnsOkResult_WithExibicao()
        {
            // Arrange
            var exibicao = new Exibicao { Id = 1 };
            _exibicaoServiceMock.Setup(service => service.GetExibicaoByIdAsync(1)).ReturnsAsync(exibicao);

            // Act
            var result = await _controller.GetExibicaoById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnExibicao = Assert.IsType<Exibicao>(okResult.Value);
            Assert.Equal(1, returnExibicao.Id);
        }

        [Fact]
        public async Task GetExibicaoById_ReturnsNotFound_WhenExibicaoDoesNotExist()
        {
            // Arrange
            _exibicaoServiceMock.Setup(service => service.GetExibicaoByIdAsync(It.IsAny<int>())).ReturnsAsync((Exibicao)null);

            // Act
            var result = await _controller.GetExibicaoById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task CreateExibicao_ReturnsCreatedAtAction()
        {
            // Arrange
            var exibicao = new Exibicao { Id = 1 };
            _exibicaoServiceMock.Setup(service => service.CreateExibicaoAsync(exibicao)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.CreateExibicao(exibicao);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetExibicaoById", createdAtActionResult.ActionName);
            Assert.Equal(1, createdAtActionResult.RouteValues["id"]);
        }

        [Fact]
        public async Task UpdateExibicao_ReturnsNoContent()
        {
            // Arrange
            var exibicao = new Exibicao { Id = 1 };
            _exibicaoServiceMock.Setup(service => service.UpdateExibicaoAsync(exibicao)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.UpdateExibicao(1, exibicao);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateExibicao_ReturnsBadRequest_WhenIdMismatch()
        {
            // Arrange
            var exibicao = new Exibicao { Id = 2 }; // ID diferente do que está na URL

            // Act
            var result = await _controller.UpdateExibicao(1, exibicao);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteExibicao_ReturnsNoContent_WhenExibicaoExists()
        {
            // Arrange
            _exibicaoServiceMock.Setup(service => service.DeleteExibicaoAsync(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteExibicao(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
