using AutoFixture;
using Castle.Core.Logging;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Pensions.Core.Models;
using Pensions.Core.Services.Interfaces;
using Pensions.Core.Services.Interfaces.Pension;
using Pensions.Host.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pensions.UnitTests.Host.Controllers
{
    public class CalculationControllerTests
    {
        private readonly Mock<IBasicService> _basicService;
        private readonly Mock<IPensionService> _pensionService;
        private readonly Mock<ILogger<CalculationController>> _logger;

        public CalculationControllerTests()
        {
            _basicService = new Mock<IBasicService>();
            _pensionService = new Mock<IPensionService>();
            _logger = new Mock<ILogger<CalculationController>>();
        }

        [Fact]
        public async Task GetAsync_ShouldReturnValueForGivenId()
        {
            var list = new Fixture().CreateMany<Basic>();
            var firstBasic = list.FirstOrDefault();
            _basicService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(firstBasic);
            var controller = new CalculationController(_pensionService.Object,_basicService.Object,_logger.Object);

            var actionResult = await controller.GetAsync(1);

            actionResult.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNotFoundForGivenId()
        {
            var list = new Fixture().CreateMany<Basic>();
            Basic firstBasic = null;
            _basicService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(firstBasic);
            var controller = new CalculationController(_pensionService.Object, _basicService.Object,_logger.Object);

            var actionResult = await controller.GetAsync(0);

            actionResult.Result.Should().BeOfType<NotFoundObjectResult>();
        }
    }
}
