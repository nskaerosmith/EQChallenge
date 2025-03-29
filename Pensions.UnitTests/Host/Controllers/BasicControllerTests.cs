using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Pensions.Core.Services.Interfaces;
using Pensions.Host.Controllers;
using Xunit;
using Pensions.Core.Models;

namespace Pensions.UnitTests.Host.Controllers
{
    public class BasicControllerTests
    {
        private readonly Mock<IBasicService> _basicService;

        public BasicControllerTests()
        {
            _basicService = new Mock<IBasicService>();
        }

        [Fact]
        public async Task GetAllAsync_ShoulrReturnAll()
        {
            var list = new Fixture().CreateMany<Basic>();
            _basicService.Setup(x => x.GetAllAsync()).ReturnsAsync(list);
            var controller = new BasicController(_basicService.Object);

            var actionResult = await controller.GetAllAsync();

            actionResult.Should().BeOfType<ActionResult<IEnumerable<Basic>>>();
            var result = actionResult.Result as OkObjectResult;
            var values = result.Value as IEnumerable<Basic>;
            values.Should().HaveCount(list.Count());
        }

        [Fact]
        public async Task GetAsync_ShoulrReturnBasicGivenId()
        {
            var list = new Fixture().CreateMany<Basic>();
            var firstBasic = list.FirstOrDefault();
            _basicService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(firstBasic);
            var controller = new BasicController(_basicService.Object);

            var actionResult = await controller.GetAsync(It.IsAny<int>());

            actionResult.Should().BeOfType<ActionResult<Basic>>();
            var result = actionResult.Result as OkObjectResult;
            result.Value.Should().Be(firstBasic);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNotFoundGivenNoMatchingId()
        {
            _basicService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(default(Basic));
            var controller = new BasicController(_basicService.Object);

            var result = await controller.GetAsync(It.IsAny<int>());

            result.Result.Should().BeOfType<NotFoundResult>();
        }
    }
}
