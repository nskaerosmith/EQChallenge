using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pensions.Core.Services.Interfaces;
using Pensions.Core.Services.Interfaces.Pension;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Pensions.Host.Controllers
{
    [Route("api/calculation")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly IPensionService _pensionService;
        private readonly IBasicService _basicService;
        private readonly ILogger<CalculationController> _logger;

        public CalculationController(IPensionService pensionService, IBasicService basicService, ILogger<CalculationController> logger)
        {
            this._pensionService = pensionService;
            this._basicService = basicService;
            this._logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<double>> GetAsync(int Id,bool saveCalculation=false)
        {
            try
            {
                var member = await _basicService.GetByIdAsync(Id);
                if (member == null)
                {
                    return NotFound("Member not found");
                }
                if (saveCalculation)
                {
                    return Ok(await this._pensionService.GetPensionByIdAsync(Id, true));
                }
                var content = await this._pensionService.GetPensionByIdAsync(Id);
                return this.Ok(content);
            }
            catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Error calculating pension");
            }
        }
    }
}
