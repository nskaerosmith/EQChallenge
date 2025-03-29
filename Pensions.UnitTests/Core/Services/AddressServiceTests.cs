using System.Threading.Tasks;
using Moq;
using Pensions.Core.Models;
using Pensions.Core.Persistence.Interfaces;
using Pensions.Core.Services;
using Xunit;

namespace Pensions.UnitTests.Core.Services
{
    public class AddressServiceTests
    {
        private readonly Mock<IAddressRepository> _addressRepository;

        public AddressServiceTests()
        {
            this._addressRepository = new Mock<IAddressRepository>();
        }

        [Fact]
        public async Task GetAsync_ShouldCallGetByMemberIdAsync()
        {
            this._addressRepository.Setup(x => x.GetByMemberIdAsync(It.IsAny<int>())).ReturnsAsync(default(Address));
            var sut = new AddressService(this._addressRepository.Object);

            await sut.GetAsync(It.IsAny<int>());

            this._addressRepository.Verify(x => x.GetByMemberIdAsync(It.IsAny<int>()), Times.Once);
            this._addressRepository.Verify(x => x.AddAsync(It.IsAny<Address>()), Times.Never);
            this._addressRepository.Verify(x => x.UpdateAsync(It.IsAny<Address>()), Times.Never);
        }

        [Fact]
        public async Task AddAsync_ShouldCallAddAsync()
        {
            this._addressRepository.Setup(x => x.AddAsync(It.IsAny<Address>()));
            var sut = new AddressService(this._addressRepository.Object);

            await sut.AddAsync(It.IsAny<Address>());

            this._addressRepository.Verify(x => x.GetByMemberIdAsync(It.IsAny<int>()), Times.Never);
            this._addressRepository.Verify(x => x.AddAsync(It.IsAny<Address>()), Times.Once);
            this._addressRepository.Verify(x => x.UpdateAsync(It.IsAny<Address>()), Times.Never);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallUpdateAsync()
        {
            this._addressRepository.Setup(x => x.UpdateAsync(It.IsAny<Address>()));
            var sut = new AddressService(this._addressRepository.Object);

            await sut.UpdateAsync(It.IsAny<Address>());

            this._addressRepository.Verify(x => x.GetByMemberIdAsync(It.IsAny<int>()), Times.Never);
            this._addressRepository.Verify(x => x.AddAsync(It.IsAny<Address>()), Times.Never);
            this._addressRepository.Verify(x => x.UpdateAsync(It.IsAny<Address>()), Times.Once);
        }
    }
}
