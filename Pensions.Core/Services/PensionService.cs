using Pensions.Core.Persistence.Interfaces.PensionCalculator;
using Pensions.Core.Services.Interfaces.Pension;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pensions.Core.Services
{
    public class PensionService : IPensionService
    {
        private readonly IPensionCalculator _pensionCalculator;

        public PensionService(IPensionCalculator pensionCalculator)
        {
            _pensionCalculator = pensionCalculator;
        }
        public Task<double> GetPensionByIdAsync(int basicId, bool saveCalculations)
        {
            return _pensionCalculator.GetPensionByIdAsync(basicId,saveCalculations);
        }
    }
}
