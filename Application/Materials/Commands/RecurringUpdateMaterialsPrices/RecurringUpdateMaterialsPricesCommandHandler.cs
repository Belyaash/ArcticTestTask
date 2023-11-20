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

namespace Application.Materials.Commands.RecurringUpdateMaterialsPrices
{
    public class RecurringUpdateMaterialsPricesCommandHandler :
        IRequestHandler<RecurringUpdateMaterialsPricesCommand, Unit>
    {
        private readonly IApplicationDbContext _dbContext;
        public RecurringUpdateMaterialsPricesCommandHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(RecurringUpdateMaterialsPricesCommand request,
            CancellationToken cancellationToken)
        {
            var entities = await _dbContext.Materials
                 .ToListAsync(cancellationToken);

            foreach (var entity in entities)
            {
                Random rnd = new Random();
                entity.Price = rnd.Next(1,100);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
