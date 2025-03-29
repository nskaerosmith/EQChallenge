using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pensions.Core.Models;
using Pensions.Core.Persistence.Interfaces;
using Pensions.Persistence.DbContexts;

namespace Pensions.Persistence.Repositories
{
    public class BasicRepository : IBasicRepository
    {
        private readonly PensionsContext _context;
        private readonly IMapper _mapper;

        public BasicRepository(PensionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Basic>> GetAllAsync()
        {
            var basicEntity = await _context.Basic.ToListAsync().ConfigureAwait(false);

            return _mapper.Map<IEnumerable<Entities.Basic>, IEnumerable<Basic>>(basicEntity);
        }

        public async Task<Basic> GetByIdAsync(int id)
        {
            var basicEntity = await this._context.Basic.FirstOrDefaultAsync(b => b.Id == id);

            return _mapper.Map<Entities.Basic, Basic>(basicEntity);
        }
    }
}
