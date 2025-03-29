using System.Collections.Generic;
using System.Threading.Tasks;
using Pensions.Core.Models;

namespace Pensions.Core.Persistence.Interfaces
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetByMemberId(int memberId);
    }
}
