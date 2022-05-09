using EldoradoWebApi.Controllers;
using EldoradoWebApi.Models.Addresses;
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
    public class AddressController_Should
    {

        [Fact]
        public async Task GetAddress_ReturnAddress()
        {
            //Arrange
            var moqAddressService = new Mock<IAddressService>();
            var sut = new AddressController(moqAddressService.Object);

            //Act
            var result = await sut.GetAddress(1);

            //Assert

             Assert.IsType<OkObjectResult>(result);
            //Assert.IsType<AddressObject>(okObjectresult.Value);
            //var okObjectresult =
        }

        [Fact]
        public async Task GetAddresses_ReturnAddresses()
        {
            //Arrange
            var moqAddressService = new Mock<IAddressService>();
            moqAddressService.Setup(service => service.GetAddresses())
                .ReturnsAsync(new List<AddressObject>());
            var sut = new AddressController(moqAddressService.Object);

            //Act
            var result = await sut.GetAddresses();

            //Assert
            moqAddressService.Verify(service => service.GetAddresses(), Times.Once());
            var okObjectresult = Assert.IsType<OkObjectResult>(result);

        }
        [Fact]
        public async Task CreateAddress_ReturnCreatedAddress()
        {    //Arrange

            var moqAddressService = new Mock<IAddressService>();
            var sut = new AddressController(moqAddressService.Object);

            //Act
            var result = await sut.CreateAddress(new AddressCreate(1, "Gata 1", "Stad 1", "123124"));

            Assert.IsType<CreatedResult>(result);
        }
    }
}
