using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Materials.Commands.CreateMaterial
{
    public class CreateMaterialCommandValidator: AbstractValidator<CreateMaterialCommand>
    {
        public CreateMaterialCommandValidator() 
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Price).GreaterThan(0);
        }
    }
}
