using EldoradoWebApi.Controllers;
using EldoradoWebApi.Models.Colors;
using EldoradoWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EldoradoWebApi.Tests
{
   
    public class ColorController_Should
    {

        [Fact]
        public async Task CreateColor_that_exists()
        {
            //Arrange
            var moqColorService = new Mock<IColorService>();
            var sut = new ColorsController(moqColorService.Object);
            //Act
            var result = await sut.CreateColor(new ColorCreate("blue"));

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }



        [Fact]
        public async Task GetColors_ReturnColors()
        {
            //Arrange
            var moqColorService = new Mock<IColorService>();
            moqColorService.Setup(service => service.GetColors())
                .ReturnsAsync(new List<ColorObject>());
            var sut = new ColorsController(moqColorService.Object);

            //Act
            var result = await sut.GetColors();

            //Assert
            moqColorService.Verify(service => service.GetColors(),
                Times.Once());
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
        }

       

       
    }
}
