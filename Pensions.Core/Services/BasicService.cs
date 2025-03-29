using System.Collections.Generic;
using System.Threading.Tasks;
using Pensions.Core.Models;
using Pensions.Core.Persistence.Interfaces;
using Pensions.Core.Services.Interfaces;

namespace Pensions.Core.Services
{
    public class BasicService : IBasicService
    {
        private readonly IBasicRepository _basicRepository;

        public BasicService(IBasicRepository basicRepository)
        {
            _basicRepository = basicRepository;
        }

        public async Task<IEnumerable<Basic>> GetAllAsync()
        {
            return await this._basicRepository.GetAllAsync();
        }

        public async Task<Basic> GetByIdAsync(int id)
        {
            return await this._basicRepository.GetByIdAsync(id);
        }
    }
}
