using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Materials.Commands.CreateMaterial
{
    public class CreateMaterialCommand: IRequest<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int SellerId { get; set; }
    }
}
