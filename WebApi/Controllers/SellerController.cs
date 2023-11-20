
using Application.Sellers.Commands.CreateSeller;
using Application.Sellers.Commands.DeleteSeller;
using Application.Sellers.Commands.UpdateSeller;
using Application.Sellers.Queries.GetSellerDetail;
using Application.Sellers.Queries.GetSellerList;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controller for api interactions with Sellers table
    /// </summary>
    [Route("api/[controller]")]
    public class SellerController : BaseController
    {
        /// <summary>
        /// Gets the list of sellers
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /seller
        /// </remarks>
        /// <returns>Returns List(Seller)</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Seller>>> GetAll()
        {
            var query = new GetSellerListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the seller by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /seller/1
        /// </remarks>
        /// <param name="id">Seller id </param>
        /// <returns>Returns Seller</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Seller>> Get(int Id)
        {
            var query = new GetSellerDetailQuery()
            {
                Id = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the seller
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /seller
        /// {
        ///     name: "seller title",
        /// }
        /// </remarks>
        /// <param name="CreateSellerCommand">CreateSellerCommand object</param>
        /// <returns>Returns id</returns>
        /// <response code="201">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Create([FromBody] CreateSellerCommand command)
        {
            var noteId = await Mediator.Send(command);
            return noteId;
        }

        /// <summary>
        /// Updates the seller
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /seller
        /// {
        ///     id: id
        ///     name: "seller title",
        /// }
        /// </remarks>
        /// <param name="UpdateSellerCommand">UpdateSellerCommand object</param>
        /// <returns>Returns Ok</returns>
        /// <response code="200">Success</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] UpdateSellerCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Deletes the seller by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /seller/1
        /// </remarks>
        /// <param name="id">Id of the seller</param>
        /// <returns>Returns Ok</returns>
        /// <response code="200">Success</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
