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
            var filmes = new List<Filme>
            {
                new Filme
                {
                    Id = 1,
                    Titulo = "Filme 1",
                    Genero = "Ação",
                    Duracao = 120,
                    AnoLancamento = 2023
                }
            };
            _filmeServiceMock.Setup(service => service.GetAllFilmesAsync()).ReturnsAsync(filmes);

            // Act
            var result = await _controller.GetAllFilmes();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var filmesResult = Assert.IsType<List<Filme>>(okResult.Value);
            Assert.Single(filmesResult);
            Assert.Equal("Filme 1", filmesResult[0].Titulo);
            Assert.Equal("Ação", filmesResult[0].Genero);
            Assert.Equal(120, filmesResult[0].Duracao);
            Assert.Equal(2023, filmesResult[0].AnoLancamento);
        }

    }
}
