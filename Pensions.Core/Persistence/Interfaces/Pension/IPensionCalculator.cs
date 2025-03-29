using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pensions.Core.Persistence.Interfaces.PensionCalculator
{
    public interface IPensionCalculator
    {
        Task<double> GetPensionByIdAsync(int basicId,bool saveCalulations=false);
    }
}
