using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pensions.Core.Persistence.Interfaces
{
    public interface IAccrualRepository
    {
        Task<double> GetByMemberEndDateAsync(DateTime endDate);
    }
}
