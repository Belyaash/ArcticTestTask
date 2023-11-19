using Application.Extentions;
using Application.Interfaces;
using Application.Materials.Commands.CreateMaterial;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Materials.Commands.UpdateMaterial
{
    public class UpdateMaterialCommandHandler : IRequestHandler<UpdateMaterialCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateMaterialCommandHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(UpdateMaterialCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Materials.FirstOrDefaultAsync(
                material => material.Id == request.Id, cancellationToken);

            if ((entity == null) || (entity.Id != request.Id))
            {
                throw new NotFoundException(nameof(Material), request.Id);
            }

            entity.Price = request.Price;
            entity.SellerId = request.SellerId;
            entity.Name = request.Name;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
