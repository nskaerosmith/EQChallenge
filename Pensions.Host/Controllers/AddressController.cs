using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pensions.Core.Models;
using Pensions.Core.Services.Interfaces;

namespace Pensions.Host.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            this._addressService = addressService;
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Address>> GetAsync(int id)
        {
            var content = await this._addressService.GetAsync(id);

            if (content == null)
            {
                return this.NotFound();
            }

            return this.Ok(content);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostAsync(Address address)
        {
            var existingAddress = await this.DoesAddressExistForMemberAsync(address.BasicId);

            if (existingAddress)
            {
                return this.BadRequest("Member already has an address");
            }

            await this._addressService.AddAsync(address);

            return this.CreatedAtAction("GetAsync", new { id = address.BasicId }, address);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Address>> PutAsync(Address address)
        {
            var existingAddress = await this.DoesAddressExistForMemberAsync(address.BasicId);

            if (!existingAddress)
            {
                return this.BadRequest("Member does not have an address");
            }

            await this._addressService.UpdateAsync(address);

            return this.Ok(address);
        }

        private async Task<bool> DoesAddressExistForMemberAsync(int id)
        {
            var existingAddress = await this._addressService.GetAsync(id);

            return existingAddress != null;
        }
    }
}
