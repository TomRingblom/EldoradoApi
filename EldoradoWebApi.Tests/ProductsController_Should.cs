using EldoradoWebApi.Controllers;
using EldoradoWebApi.Models.Products;
using EldoradoWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EldoradoWebApi.Tests
{
    public class ProductsController_Should
    {
        [Fact]
        public async Task GetAllProducts_ReturnAllProducts()
        {
            //Arrange
            var moqProductService = new Mock<IProductService>();
            moqProductService.Setup(service => service.GetProducts())
                .ReturnsAsync(new List<ProductObject>());
            var sut = new ProductsController(moqProductService.Object);

            //Act
            var result = await sut.GetProducts();

            //Assert
            moqProductService.Verify(service => service.GetProducts(), 
                Times.Once());
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
        }
    }
}
