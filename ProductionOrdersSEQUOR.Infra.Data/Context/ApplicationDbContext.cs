using Microsoft.EntityFrameworkCore;
using ProductionOrderSEQUOR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { } 

                                // PROPRIEDADES DAS MINHAS ENTIDADES // 

        public DbSet<User> User { get; set; }
        public DbSet<ProductMaterial> ProductionMaterial { get; set; }
        public DbSet<Production> Production { get; set; }
        public DbSet<Product> Product { get; set; }

        public DbSet<Material> Material { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        // public DbSet<Order> Order { get; set; } removida



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly); 
        }
    }
}
