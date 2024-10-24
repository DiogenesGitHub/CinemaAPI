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
    public class SalasControllerTests
    {
        private readonly Mock<ISalaService> _salaServiceMock;
        private readonly SalasController _controller;

        public SalasControllerTests()
        {
            _salaServiceMock = new Mock<ISalaService>();
            _controller = new SalasController(_salaServiceMock.Object);
        }

        [Fact]
        public async Task GetAllSalas_ReturnsOk_WhenSalasExist()
        {
            // Arrange
            var Salas = new List<Sala> { new Sala { Id = 1 }, new Sala { Id = 2 } };

            _salaServiceMock.Setup(service => service.GetAllSalasAsync()).ReturnsAsync(Salas);

            // Act
            var result = await _controller.GetAllSalas();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnSalas = Assert.IsType<List<Sala>>(okResult.Value);
            Assert.Equal(2, returnSalas.Count);
        }

        [Fact]
        public async Task GetSalasById_ReturnsOkResult_WithSalas()
        {
            // Arrange
            var Sala = new Sala { Id = 1 };
            _salaServiceMock.Setup(service => service.GetSalaByIdAsync(1)).ReturnsAsync(Sala);

            // Act
            var result = await _controller.GetSalaById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnSalas = Assert.IsType<Sala>(okResult.Value);
            Assert.Equal(1, returnSalas.Id);
        }

        [Fact]
        public async Task GetSalasById_ReturnsNotFound_WhenSalasDoesNotExist()
        {
            // Arrange
            _salaServiceMock.Setup(service => service.GetSalaByIdAsync(It.IsAny<int>())).ReturnsAsync((Sala)null);

            // Act
            var result = await _controller.GetSalaById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task CreateSalas_ReturnsCreatedAtAction()
        {
            // Arrange
            var Sala = new Sala { Id = 1 };
            _salaServiceMock.Setup(service => service.CreateSalaAsync(Sala)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.CreateSala(Sala);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetSalaById", createdAtActionResult.ActionName);
            Assert.Equal(1, createdAtActionResult.RouteValues["id"]);
        }

        [Fact]
        public async Task UpdateSalas_ReturnsNoContent()
        {
            // Arrange
            var Sala = new Sala { Id = 1 };
            _salaServiceMock.Setup(service => service.UpdateSalaAsync(Sala)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.UpdateSala(1, Sala);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateSalas_ReturnsBadRequest_WhenIdMismatch()
        {
            // Arrange
            var Sala = new Sala { Id = 2 };

            // Act
            var result = await _controller.UpdateSala(1, Sala);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteSalas_ReturnsNoContent_WhenSalasoExists()
        {
            // Arrange
            _salaServiceMock.Setup(service => service.DeleteSalaAsync(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteSala(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
