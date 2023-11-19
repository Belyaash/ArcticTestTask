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

namespace Application.Sellers.Commands.UpdateSeller
{
    public class UpdateSellerCommandHandler : IRequestHandler<UpdateSellerCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateSellerCommandHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(UpdateSellerCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Sellers.FirstOrDefaultAsync(
                seller => seller.Id == request.Id, cancellationToken);

            if ((entity == null) || (entity.Id != request.Id))
            {
                throw new NotFoundException(nameof(Seller), request.Id);
            }

            entity.Name = request.Name;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
