using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pensions.Core.Persistence.Interfaces;
using Pensions.Persistence.DbContexts;

namespace Pensions.Persistence.Repositories
{
    public class AccrualRepository : IAccrualRepository
    {
        private readonly PensionsContext _context;

        public AccrualRepository(PensionsContext context)
        {
            _context = context;
        }

        public async Task<double> GetByMemberEndDateAsync(DateTime endDate)
        {
            return await this._context.Accrual
                .Where(x => x.EffectiveDate <= endDate)
                .OrderByDescending(x => x.EffectiveDate)
                .Select(x => x.Rate)
                .FirstOrDefaultAsync();
        }
    }
}
