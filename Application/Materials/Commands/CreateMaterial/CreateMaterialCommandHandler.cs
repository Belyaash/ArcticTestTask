using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Materials.Commands.CreateMaterial
{
    public class CreateMaterialCommandHandler : IRequestHandler<CreateMaterialCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateMaterialCommandHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateMaterialCommand request,
            CancellationToken cancellationToken)
        {
            var entity = new Material()
            {
                Name = request.Name,
                SellerId = request.SellerId,
                Price = request.Price,
            };

            await _dbContext.Materials.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
