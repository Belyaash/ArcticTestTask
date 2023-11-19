using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Materials.Queries.GetMaterialList
{
    public class GetMaterialListQueryHandler:
        IRequestHandler<GetMaterialListQuery, List<Material>>
    {

        private readonly IApplicationDbContext _dbContext;
        public GetMaterialListQueryHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<List<Material>> Handle(GetMaterialListQuery request,
            CancellationToken cancellationToken)
        {
            return await _dbContext.Materials.ToListAsync();
        }
    }
}
