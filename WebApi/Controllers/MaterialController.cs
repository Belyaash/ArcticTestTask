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
    [Route("api/[controller]")]
    public class MaterialController: BaseController
    {

        [HttpGet]
        public async Task<ActionResult<List<Material>>> GetAll()
        {
            var query = new GetMaterialListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> Get(int Id)
        {
            var query = new GetMaterialDetailsQuery()
            {
                Id = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateMaterialCommand command)
        {
            var noteId = await Mediator.Send(command);
            return noteId;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateMaterialCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
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
