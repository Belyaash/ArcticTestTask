using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Materials.Queries.GetMaterialList;
using Application.Materials.Queries.GetMaterialDetail;
using MediatR;
using Application.Materials.Commands.CreateMaterial;
using Application.Materials.Commands.UpdateMaterial;
using Application.Materials.Commands.DeleteMaterial;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controller for api interactions with Material table
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MaterialController: BaseController
    {

        /// <summary>
        /// Gets the list of materials
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /material
        /// </remarks>
        /// <returns>Returns List(Material)</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Material>>> GetAll()
        {
            var query = new GetMaterialListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the material by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /material/1
        /// </remarks>
        /// <param name="id">Material id </param>
        /// <returns>Returns Material</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Material>> Get(int Id)
        {
            var query = new GetMaterialDetailsQuery()
            {
                Id = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the material
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /material
        /// {
        ///     name: "material title",
        ///     price: 10.0
        ///     sellerId: 1
        /// }
        /// </remarks>
        /// <param name="CreateMaterialCommand">CreateMaterialCommand object</param>
        /// <returns>Returns id</returns>
        /// <response code="201">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Create([FromBody] CreateMaterialCommand command)
        {
            var noteId = await Mediator.Send(command);
            return noteId;
        }

        /// <summary>
        /// Updates the material
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /material
        /// {
        ///     id: id
        ///     name: "material title",
        ///     price: 10.0
        ///     sellerId: 1
        /// }
        /// </remarks>
        /// <param name="UpdateMaterialCommand">UpdateMaterialCommand object</param>
        /// <returns>Returns Ok</returns>
        /// <response code="200">Success</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] UpdateMaterialCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Deletes the material by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /material/1
        /// </remarks>
        /// <param name="id">Id of the material</param>
        /// <returns>Returns Ok</returns>
        /// <response code="200">Success</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int Id)
        {
            var command = new DeleteMaterialCommand
            {
                Id = Id
            };
            await Mediator.Send(command);
            return Ok();
        }

    }
}
