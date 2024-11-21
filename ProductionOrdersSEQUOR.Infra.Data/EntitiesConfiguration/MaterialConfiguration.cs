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
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MaterialCode).IsRequired();
            builder.Property(x => x.MaterialDescription).IsRequired();

        }
    }
}
