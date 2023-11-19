using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Sellers.Commands.CreateSeller
{
    public class CreateSellerCommandHandler : IRequestHandler<CreateSellerCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateSellerCommandHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateSellerCommand request,
            CancellationToken cancellationToken)
        {
            var entity = new Seller()
            {
                Name = request.Name,
            };

            await _dbContext.Sellers.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
