using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pensions.Core.Models;
using Pensions.Core.Persistence.Interfaces;
using Pensions.Persistence.DbContexts;

namespace Pensions.Persistence.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly PensionsContext _context;
        private readonly IMapper _mapper;

        public AddressRepository(PensionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Address> GetByMemberIdAsync(int memberId)
        {
            var addressEntity = await this._context.Address
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.BasicId == memberId);

            return this._mapper.Map<Entities.Address, Address>(addressEntity);
        }

        public async Task AddAsync(Address address)
        {
            var addressEntity = this._mapper.Map<Address, Entities.Address>(address);
            this._context.Address.Add(addressEntity);
            await this._context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Address address)
        {
            var addressEntity = this._mapper.Map<Address, Entities.Address>(address);
            this._context.Address.Update(addressEntity);
            var x = await this._context.SaveChangesAsync();
        }
    }
}
