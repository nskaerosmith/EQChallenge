using Moq;
using Pensions.Core.Persistence.Interfaces;
using Pensions.Core.Persistence.Interfaces.PensionCalculator;
using Pensions.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pensions.UnitTests.Core.Services
{
    public class PensionServiceTests
    {
        private readonly Mock<IPensionCalculator> _pensionCalculator;

        public PensionServiceTests()
        {
            this._pensionCalculator = new Mock<IPensionCalculator>();
        }

        [Fact]
        public async Task GetAsync_ShouldCallGetByMemberIdAsync()
        {
           
            var ps = new PensionService(this._pensionCalculator.Object);

            await ps.GetPensionByIdAsync(It.IsAny<int>(),false);

            this._pensionCalculator.Verify(x => x.GetPensionByIdAsync(It.IsAny<int>(),false), Times.Once);
            
        }
    }
}
