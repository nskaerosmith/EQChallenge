using System.Collections.Generic;
using System.Threading.Tasks;
using Pensions.Core.Models;

namespace Pensions.Core.Persistence.Interfaces
{
    public interface IBasicRepository
    {
        Task<IEnumerable<Basic>> GetAllAsync();

        Task<Basic> GetByIdAsync(int id);
    }
}
