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

    public class FilmesControllerTests
    {
        private readonly Mock<IFilmeService> _filmeServiceMock;
        private readonly FilmesController _controller;

        public FilmesControllerTests()
        {
            _filmeServiceMock = new Mock<IFilmeService>();
            _controller = new FilmesController(_filmeServiceMock.Object);
        }

        [Fact]
        public async Task GetAllFilmes_ReturnsOk_WhenFilmesExist()
        {
            // Arrange
            var filmes = new List<Filme> { new Filme { Id = 1 }, new Filme { Id = 2 } };

            _filmeServiceMock.Setup(service => service.GetAllFilmesAsync()).ReturnsAsync(filmes);

            // Act
            var result = await _controller.GetAllFilmes();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnExibicoes = Assert.IsType<List<Filme>>(okResult.Value);
            Assert.Equal(2, returnExibicoes.Count);
        }

        [Fact]
        public async Task GetFilmesById_ReturnsOkResult_WithFilmes()
        {
            // Arrange
            var filme = new Filme { Id = 1 };
            _filmeServiceMock.Setup(service => service.GetFilmeByIdAsync(1)).ReturnsAsync(filme);

            // Act
            var result = await _controller.GetFilmeById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnExibicao = Assert.IsType<Filme>(okResult.Value);
            Assert.Equal(1, returnExibicao.Id);
        }

        [Fact]
        public async Task GetFilmesById_ReturnsNotFound_WhenFilmesDoesNotExist()
        {
            // Arrange
            _filmeServiceMock.Setup(service => service.GetFilmeByIdAsync(It.IsAny<int>())).ReturnsAsync((Filme)null);

            // Act
            var result = await _controller.GetFilmeById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task CreateFilmes_ReturnsCreatedAtAction()
        {
            // Arrange
            var filme = new Filme { Id = 1 };
            _filmeServiceMock.Setup(service => service.CreateFilmeAsync(filme)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.CreateFilme(filme);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetFilmeById", createdAtActionResult.ActionName);
            Assert.Equal(1, createdAtActionResult.RouteValues["id"]);
        }

        [Fact]
        public async Task UpdateFilmes_ReturnsNoContent()
        {
            // Arrange
            var filme = new Filme { Id = 1 };
            _filmeServiceMock.Setup(service => service.UpdateFilmeAsync(filme)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.UpdateFilme(1, filme);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateFilmes_ReturnsBadRequest_WhenIdMismatch()
        {
            // Arrange
            var filme = new Filme { Id = 2 };

            // Act
            var result = await _controller.UpdateFilme(1, filme);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteFilmes_ReturnsNoContent_WhenFilmesoExists()
        {
            // Arrange
            _filmeServiceMock.Setup(service => service.DeleteFilmeAsync(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteFilme(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
