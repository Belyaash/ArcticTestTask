using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Sellers.Queries.GetSellerList
{
    public class GetSellerListQueryHAndler :
        IRequestHandler<GetSellerListQuery, List<Seller>>
    {

        private readonly IApplicationDbContext _dbContext;
        public GetSellerListQueryHAndler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<List<Seller>> Handle(GetSellerListQuery request,
            CancellationToken cancellationToken)
        {
            return await _dbContext.Sellers.ToListAsync();
        }
    }
}
