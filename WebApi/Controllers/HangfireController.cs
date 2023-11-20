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
    [Route("api/[controller]")]
    public class HangfireController : BaseController
    {
        [HttpPost]
        [Route("recurring")]
        public async Task<IActionResult> Recurring()
        {
            var command = new RecurringUpdateMaterialsPricesCommand();
            Mediator.AddOrUpdate<Unit>(command, "0 8 * * *");

            return Ok();
        }
    }
}
