using System.Collections.Generic;
using System.Threading.Tasks;
using Pensions.Core.Models;

namespace Pensions.Core.Services.Interfaces
{
    public interface IBasicService
    {
        Task<IEnumerable<Basic>> GetAllAsync();

        Task<Basic> GetByIdAsync(int id);
    }
}
