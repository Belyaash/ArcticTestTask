using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityTypeConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Material> Materials { get; set; }

        public DbSet<Seller> Sellers { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MaterialConfiguration());
            builder.ApplyConfiguration(new SellerConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
