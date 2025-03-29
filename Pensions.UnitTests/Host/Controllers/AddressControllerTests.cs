using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Pensions.Core.Models;
using Pensions.Core.Services.Interfaces;
using Pensions.Host.Controllers;
using Xunit;

namespace Pensions.UnitTests.Host.Controllers
{
    public class AddressControllerTests
    {
        private readonly Mock<IAddressService> _addressService;
        
        public AddressControllerTests()
        {
            this._addressService = new Mock<IAddressService>();
        }

        [Fact]
        public async Task GetAsync_ShouldReturnAddress()
        {
            var fixture = new Fixture();
            var address = fixture.Create<Address>();
            this._addressService.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(address);
            var controller = new AddressController(this._addressService.Object);

            var actionResult = await controller.GetAsync(It.IsAny<int>());

            actionResult.Should().BeOfType<ActionResult<Address>>();
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNotFoundGivenNoAddress()
        {
            this._addressService.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(default(Address));
            var controller = new AddressController(this._addressService.Object);

            var actionResult = await controller.GetAsync(It.IsAny<int>());

            actionResult.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task PostAsync_ShouldAddAddressGivenNoExistingAddress()
        {
            var fixture = new Fixture();
            var address = fixture.Create<Address>();
            this._addressService.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(default(Address));
            this._addressService.Setup(x => x.AddAsync(It.IsAny<Address>()));
            var controller = new AddressController(this._addressService.Object);

            var actionResult = await controller.PostAsync(address);

            actionResult.Should().BeOfType<CreatedAtActionResult>();
        }

        [Fact]
        public async Task PostAsync_ShouldReturnBadRequestGivenExistingAddress()
        {
            var fixture = new Fixture();
            var address = fixture.Create<Address>();
            this._addressService.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(address);
            var controller = new AddressController(this._addressService.Object);

            var actionResult = await controller.PostAsync(address);

            actionResult.Should().BeOfType<BadRequestObjectResult>();
            this._addressService.Verify(x => x.AddAsync(It.IsAny<Address>()), Times.Never);
        }

        [Fact]
        public async Task PutAsync_ShouldReturnBadRequestGivenNoExistingAddress()
        {
            var fixture = new Fixture();
            var address = fixture.Create<Address>();
            this._addressService.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(default(Address));
            var controller = new AddressController(this._addressService.Object);

            var actionResult = await controller.PutAsync(address);

            actionResult.Result.Should().BeOfType<BadRequestObjectResult>();
            this._addressService.Verify(x => x.UpdateAsync(It.IsAny<Address>()), Times.Never);
        }

        [Fact]
        public async Task PutAsync_ShouldUpdateAddressGivenExistingAddress()
        {
            var fixture = new Fixture();
            var address = fixture.Create<Address>();
            this._addressService.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(address);
            var controller = new AddressController(this._addressService.Object);

            var actionResult = await controller.PutAsync(address);

            actionResult.Should().BeOfType<ActionResult<Address>>();
        }
    }
}
