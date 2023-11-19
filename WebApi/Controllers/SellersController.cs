
using Application.Sellers.Commands.CreateSeller;
using Application.Sellers.Commands.DeleteSeller;
using Application.Sellers.Commands.UpdateSeller;
using Application.Sellers.Queries.GetSellerDetail;
using Application.Sellers.Queries.GetSellerList;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class SellersController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<List<Seller>>> GetAll()
        {
            var query = new GetSellerListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Seller>> Get(int Id)
        {
            var query = new GetSellerDetailQuery()
            {
                Id = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateSellerCommand command)
        {
            var noteId = await Mediator.Send(command);
            return noteId;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSellerCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var command = new DeleteSellerCommand
            {
                Id = Id
            };
            await Mediator.Send(command);
            return Ok();
        }

    }
}
