using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pensions.Core.Models;
using Pensions.Core.Persistence.Interfaces;
using Pensions.Persistence.DbContexts;

namespace Pensions.Persistence.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly PensionsContext _context;
        private readonly IMapper _mapper;

        public ServiceRepository(PensionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Service>> GetByMemberId(int memberId)
        {
            var serviceEntity = await this._context.ServiceHistory
                .Where(x => x.BasicId == memberId)
                .ToListAsync();

            return this._mapper.Map<IEnumerable<Entities.Service>, IEnumerable<Service>>(serviceEntity);
        }
    }
}
