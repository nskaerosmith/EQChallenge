using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Pensions.Core.Models;
using Pensions.Core.Persistence.Interfaces;
using Pensions.Core.Services;
using Xunit;

namespace Pensions.UnitTests.Core.Services
{
    public class BasicServiceTests
    {
        private readonly Mock<IBasicRepository> _basicRepository = new Mock<IBasicRepository>();
        private readonly BasicService _sut;

        public BasicServiceTests()
        {
            this._basicRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(default(IEnumerable<Basic>));
            this._basicRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(default(Basic));
            this._sut = new BasicService(this._basicRepository.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldCallGetAllAsync()
        {
            await this._sut.GetAllAsync();

            this._basicRepository.Verify(x => x.GetAllAsync(), Times.Once);
            this._basicRepository.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public async Task GetbyIdAsync_ShouldCallGetByIdAsync()
        {
            await this._sut.GetByIdAsync(It.IsAny<int>());

            this._basicRepository.Verify(x => x.GetAllAsync(), Times.Never);
            this._basicRepository.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
