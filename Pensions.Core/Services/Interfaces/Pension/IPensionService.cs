using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pensions.Core.Services.Interfaces.Pension
{
    public interface IPensionService
    {
        Task<double> GetPensionByIdAsync(int basicId,bool saveCalculations=false);
    }
}
