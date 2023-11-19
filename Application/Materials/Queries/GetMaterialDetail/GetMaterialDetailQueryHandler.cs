using Application.Extentions;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Materials.Queries.GetMaterialDetail
{
    public class GetMateriaDetailsHandler : IRequestHandler<GetMaterialDetailsQuery
        , Material>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetMateriaDetailsHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Material> Handle(GetMaterialDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Materials.FirstOrDefaultAsync(
                (x => x.Id == request.Id), cancellationToken);

            if ((entity == null) || (entity.Id != request.Id))
            {
                throw new NotFoundException(nameof(Material), request.Id);
            }


            return entity;
        }
    }
}
