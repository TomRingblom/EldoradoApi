using System.Linq;
using System.Threading.Tasks;
using EldoradoWebApi.Controllers;
using EldoradoWebApi.Models.Tags;
using EldoradoWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace EldoradoWebApi.Tests
{
    public class TagsControllerTests
    {
        [Fact]
        public async Task GetTag_With_Id_Who_Does_Not_Exist_Returns_NotFound()
        {
            // Arrange
            int nonExistingId = 10000;
            var repositoryStub = new Mock<ITagService>();
            repositoryStub.Setup(repo => repo.GetTagById(It.IsAny<int>())).ReturnsAsync((TagObject)null);
            var sut = new TagsController(repositoryStub.Object);

            // Act
            var result = await sut.GetTag(nonExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}