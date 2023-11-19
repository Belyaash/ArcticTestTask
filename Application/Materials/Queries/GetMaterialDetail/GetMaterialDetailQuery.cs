using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Materials.Queries.GetMaterialDetail
{
    public class GetMaterialDetailsQuery : IRequest<Material>
    {
        public int Id { get; set; }
    }
}
