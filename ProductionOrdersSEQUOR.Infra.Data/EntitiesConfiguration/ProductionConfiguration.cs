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
    public class ProductionConfiguration : IEntityTypeConfiguration<Production>
    {
        public void Configure(EntityTypeBuilder<Production> builder)
        {
            builder.HasKey(x => x.Id);  
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.MaterialCode).IsRequired();
            builder.Property(x => x.CycleTime).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.Productions)
                .HasForeignKey(x => x.Order).OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
