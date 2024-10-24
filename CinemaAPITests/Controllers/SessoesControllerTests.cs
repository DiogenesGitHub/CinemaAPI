using CinemaAPI.Controllers;
using CinemaAPI.Models;
using CinemaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAPITests.Controllers
{
    public class SessoesControllerTests
    {
        private readonly Mock<ISessaoService> _sessaoServiceMock;
        private readonly SessoesController _controller;

        public SessoesControllerTests()
        {
            _sessaoServiceMock = new Mock<ISessaoService>();
            _controller = new SessoesController(_sessaoServiceMock.Object);
        }

        [Fact]
        public async Task GetAllSessoes_ReturnsOkResult_WithListOfSessoes()
        {
            // Arrange
            var sessoes = new List<Sessao> { new Sessao { Id = 1 }, new Sessao { Id = 2 } };
            _sessaoServiceMock.Setup(service => service.GetAllSessoesAsync()).ReturnsAsync(sessoes);

            // Act
            var result = await _controller.GetAllSessoes();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnSessoes = Assert.IsType<List<Sessao>>(okResult.Value);
            Assert.Equal(2, returnSessoes.Count);
        }

        [Fact]
        public async Task GetSessoesById_ReturnsOkResult_WithSessoes()
        {
            // Arrange
            var sessoes = new Sessao { Id = 1 };
            _sessaoServiceMock.Setup(service => service.GetSessaoByIdAsync(1)).ReturnsAsync(sessoes);

            // Act
            var result = await _controller.GetSessaoById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnSessoes = Assert.IsType<Sessao>(okResult.Value);
            Assert.Equal(1, returnSessoes.Id);
        }

        [Fact]
        public async Task GetSessoesById_ReturnsNotFound_WhenSessoesDoesNotExist()
        {
            // Arrange
            _sessaoServiceMock.Setup(service => service.GetSessaoByIdAsync(It.IsAny<int>())).ReturnsAsync((Sessao)null);

            // Act
            var result = await _controller.GetSessaoById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task CreateSessoes_ReturnsCreatedAtAction()
        {
            // Arrange
            var sessoes = new Sessao { Id = 1 };
            _sessaoServiceMock.Setup(service => service.CreateSessaoAsync(sessoes)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.CreateSessao(sessoes);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetSessaoById", createdAtActionResult.ActionName);
            Assert.Equal(1, createdAtActionResult.RouteValues["id"]);
        }

        [Fact]
        public async Task UpdateSessoes_ReturnsNoContent()
        {
            // Arrange
            var sessoes = new Sessao { Id = 1 };
            _sessaoServiceMock.Setup(service => service.UpdateSessaoAsync(sessoes)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.UpdateSessao(1, sessoes);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateSessoes_ReturnsBadRequest_WhenIdMismatch()
        {
            // Arrange
            var sessoes = new Sessao { Id = 2 };

            // Act
            var result = await _controller.UpdateSessao(1, sessoes);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteSessoes_ReturnsNoContent_WhenSessoesExists()
        {
            // Arrange
            _sessaoServiceMock.Setup(service => service.DeleteSessaoAsync(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteSessao(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
