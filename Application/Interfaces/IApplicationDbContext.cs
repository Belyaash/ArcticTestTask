using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Material> Materials { get; }
        DbSet<Seller> Sellers { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
