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

            var okObjectresult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<AddressObject>(okObjectresult.Value);
        }

        [Fact]
        public async Task GetAddresses_ReturnAddresses()
        {
            //Arrange
            var moqAddressService = new Mock<IAddressService>();
            var sut = new AddressController(moqAddressService.Object);

            //Act
            var result = await sut.GetAddresses();

            //Assert
         
           var okObjectresult = Assert.IsType<OkObjectResult>(result);
           Assert.IsType<AddressObject[]>(okObjectresult.Value);

            
            
           
        }


        public async Task CreateAddress_ReturnCreatedAddress()
        {

        }
    }
}
