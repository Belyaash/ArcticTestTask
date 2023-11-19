using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Materials.Commands.DeleteMaterial
{
    public class DeleteMaterialCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
