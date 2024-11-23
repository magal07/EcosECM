using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductionOrderSEQUOR.Domain.Entities;
using System;

namespace ProductionOrderSEQUOR.Infra.Data.EntitiesConfiguration
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

            // Ajuste para garantir que as chaves estrangeiras correspondam aos tipos das chaves primárias
            builder.HasOne(x => x.User)
                   .WithMany(x => x.Productions)
                   .HasForeignKey(x => x.Id ) // Garantindo que a chave estrangeira seja UserId
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Order)
                   .WithMany(x => x.Productions)
                   .HasForeignKey(x => x.Id) // Garantindo que a chave estrangeira seja OrderId
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
