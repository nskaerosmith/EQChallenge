using Pensions.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pensions.Core.Persistence.Interfaces.PensionCalculator
{
    public interface IPensionRepository
    {

        Task AddAsync(Results results);
    }
}
