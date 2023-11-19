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

namespace Application.Materials.Commands.DeleteMaterial
{
    public class DeleteMaterialCommandHandler : 
        IRequestHandler<DeleteMaterialCommand, Unit>
    {
        private readonly IApplicationDbContext _dbContext;
        public DeleteMaterialCommandHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteMaterialCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Materials
                 .FirstOrDefaultAsync((x => x.Id == request.Id), cancellationToken);

            if ((entity == null)||(entity.Id != request.Id)) 
            {
                throw new NotFoundException(nameof(Material), request.Id);
            }
            _dbContext.Materials.Remove(entity); 
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
