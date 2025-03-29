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
    public class SalaryRepository : ISalaryRepository
    {
        private readonly PensionsContext _context;
        private readonly IMapper _mapper;

        public SalaryRepository(PensionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Salary>> GetSalariesByMemberIdAsync(int memberId)
        {
            var salaryEntity = await this._context.SalaryHistory
                .Where(x => x.BasicId == memberId)
                .ToListAsync();

            return this._mapper.Map<ICollection<Entities.Salary>, ICollection<Salary>>(salaryEntity);
        }

        public async Task<double> GetLatestSalaryByMemberIdAsync(int memberId)
        {
            return await this._context.SalaryHistory
                .Where(x => x.BasicId == memberId)
                .OrderByDescending(x => x.EffectiveDate)
                .Select(x => x.Value)
                .FirstOrDefaultAsync();
        }
    }
}
