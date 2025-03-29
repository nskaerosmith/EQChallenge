using System.Threading.Tasks;
using Pensions.Core.Models;

namespace Pensions.Core.Persistence.Interfaces
{
    public interface IAddressRepository
    {
        Task<Address> GetByMemberIdAsync(int memberId);

        Task AddAsync(Address address);

        Task UpdateAsync(Address address);
    }
}
