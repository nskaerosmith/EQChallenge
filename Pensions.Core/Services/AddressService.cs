using System.Threading.Tasks;
using Pensions.Core.Models;
using Pensions.Core.Persistence.Interfaces;
using Pensions.Core.Services.Interfaces;

namespace Pensions.Core.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Address> GetAsync(int id)
        {
            return await this._addressRepository.GetByMemberIdAsync(id);
        }

        public async Task AddAsync(Address address)
        {
            await this._addressRepository.AddAsync(address);
        }

        public async Task UpdateAsync(Address address)
        {
            await this._addressRepository.UpdateAsync(address);
        }
    }
}
