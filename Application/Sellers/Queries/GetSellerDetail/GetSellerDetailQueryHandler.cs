using Application.Extentions;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Sellers.Queries.GetSellerDetail
{
    public class GetSellerDetailQueryHandler : IRequestHandler<GetSellerDetailQuery
        ,Seller>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetSellerDetailQueryHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Seller> Handle(GetSellerDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Sellers.FirstOrDefaultAsync(
                (x => x.Id == request.Id), cancellationToken);

            if ((entity == null) || (entity.Id != request.Id))
            {
                throw new NotFoundException(nameof(Seller), request.Id);
            }


            return entity;
        }
    }
}
