using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductionOrderSEQUOR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasKey(x => x.ProductCode);
            builder.Property(x => x.ProductDescription).IsRequired();
            builder.Property(x => x.Image).IsRequired();
           // builder.Property(x => x.IDProduct).IsRequired();
            builder.Property(x => x.CycleTime).IsRequired();
        }
    }
}
