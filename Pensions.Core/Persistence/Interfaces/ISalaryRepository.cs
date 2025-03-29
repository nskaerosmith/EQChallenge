using System.Collections.Generic;
using System.Threading.Tasks;
using Pensions.Core.Models;

namespace Pensions.Core.Persistence.Interfaces
{
    public interface ISalaryRepository
    {
        Task<IEnumerable<Salary>> GetSalariesByMemberIdAsync(int memberId);

        Task<double> GetLatestSalaryByMemberIdAsync(int memberId);
    }
}
