using System.Threading.Tasks;
using Pensions.Core.Models;

namespace Pensions.Core.Services.Interfaces
{
    public interface IAddressService
    {
        Task<Address> GetAsync(int id);

        Task AddAsync(Address address);

        Task UpdateAsync(Address address);
    }
}
