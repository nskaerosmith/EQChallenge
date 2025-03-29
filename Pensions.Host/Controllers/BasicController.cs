using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pensions.Core.Services.Interfaces;
using Pensions.Persistence.Entities;

namespace Pensions.Host.Controllers
{
    [Route("api/basic")]
    [ApiController]
    public class BasicController : ControllerBase
    {
        private readonly IBasicService _basicService;

        public BasicController(IBasicService basicService)
        {
            this._basicService = basicService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Core.Models.Basic>>> GetAllAsync()
        {
            var content = await this._basicService.GetAllAsync();

            return this.Ok(content);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Core.Models.Basic>> GetAsync(int id)
        {
            var content = await this._basicService.GetByIdAsync(id);

            if (content == null)
            {
                return NotFound();
            }

            return this.Ok(content);
        }
    }
}
