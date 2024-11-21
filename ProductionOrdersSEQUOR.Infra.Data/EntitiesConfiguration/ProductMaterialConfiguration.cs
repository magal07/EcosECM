using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductionOrdersSEQUOR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrdersSEQUOR.Infra.Data.EntitiesConfiguration
{
    public class ProductMaterialConfiguration : IEntityTypeConfiguration<ProductMaterial>
    {
        public void Configure(EntityTypeBuilder<ProductMaterial> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasKey(x => x.ProductCode);
            builder.Property(x => x.MaterialCode).IsRequired();
            builder.Property(x => x.IDProductMaterial).IsRequired();
        }
    }
}
