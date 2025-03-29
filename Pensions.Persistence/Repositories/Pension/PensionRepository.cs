using AutoMapper;
using Pensions.Core.Models;
using Pensions.Core.Persistence.Interfaces.PensionCalculator;
using Pensions.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pensions.Persistence.Repositories.PensionCalculator
{
    public class PensionRepository:IPensionRepository
    {

        private readonly PensionsContext _context;
        private readonly IMapper _mapper;

        public PensionRepository(PensionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(Results results)
        {
            try
            {
                var resultsEntity = this._mapper.Map<Results, Entities.Results>(results);
                this._context.Results.Add(resultsEntity);
                await this._context.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
