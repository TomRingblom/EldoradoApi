using System.Net;
using System.Threading.Tasks;
using EldoradoWebApi.Controllers;
using EldoradoWebApi.Models.Entities;
using EldoradoWebApi.Models.Sizes;
using EldoradoWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using Xunit;

namespace EldoradoWebApi.Tests;

public class SizesController_Should
{
    [Fact]
    public void Check_If_DeleteSize_Has_Authorize_Attribute()
    {
        //Arrange
        var mock = new Mock<ISizeService>();
        var sut = new SizesController(mock.Object);
        
        //Act
        var result = sut.GetType().GetMethod("DeleteSize").GetCustomAttributes(typeof(AuthorizeAttribute), true);

        //Assert
        Assert.Equal(typeof(AuthorizeAttribute), result[0].GetType());
    }

    [Fact]
    public void Check_If_UpdateSize_Has_Authorize_Attribute()
    {
        //Arrange
        var mock = new Mock<ISizeService>();
        var sut = new SizesController(mock.Object);

        //Act
        var result = sut.GetType().GetMethod("UpdateSize").GetCustomAttributes(typeof(AuthorizeAttribute), true);

        //Assert
        Assert.Equal(typeof(AuthorizeAttribute), result[0].GetType());
    }
}