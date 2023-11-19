using Application.Extentions;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Sellers.Commands.DeleteSeller
{
    public class DeleteSellerCommandHandler :
        IRequestHandler<DeleteSellerCommand, Unit>
    {
        private readonly IApplicationDbContext _dbContext;
        public DeleteSellerCommandHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteSellerCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Sellers
                 .FirstOrDefaultAsync((x => x.Id == request.Id), cancellationToken);

            if ((entity == null) || (entity.Id != request.Id))
            {
                throw new NotFoundException(nameof(Seller), request.Id);
            }
            _dbContext.Sellers.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
