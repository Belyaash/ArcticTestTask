using Application.Materials.Commands.RecurringUpdateMaterialsPrices;
using Application.Materials.Queries.GetMaterialList;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.MediatRHangfireBridge;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controller for all hangfire Tasks
    /// </summary>

    [Route("api/[controller]")]
    public class HangfireController : BaseController
    {
        /// <summary>
        /// Starts cron than will change prices of every material at 8 AM every day
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /recurring
        /// </remarks>
        /// <returns>None</returns>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("recurring")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Recurring()
        {
            var command = new RecurringUpdateMaterialsPricesCommand();
            Mediator.AddOrUpdate(command, "0 8 * * *");

            return Ok();
        }
    }
}
