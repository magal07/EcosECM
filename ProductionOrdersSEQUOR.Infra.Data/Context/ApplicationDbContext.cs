using Microsoft.EntityFrameworkCore;
using ProductionOrdersSEQUOR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrdersSEQUOR.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { } 

                                // PROPRIEDADES DAS MINHAS ENTIDADES // 

        public DbSet<User>? User { get; set; }
        public DbSet<ProductMaterial>? ProductionMaterial { get; set; }
        public DbSet<Production>? Production { get; set; }
        public DbSet<Product>? Product { get; set; }
        public DbSet<Order>? Order { get; set; }
        public DbSet<Material>? Material { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly); 
        }
    }
}
