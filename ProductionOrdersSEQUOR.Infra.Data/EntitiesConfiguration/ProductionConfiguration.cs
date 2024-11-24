using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductionOrderSEQUOR.Domain.Entities;

namespace ProductionOrderSEQUOR.Infra.Data.EntitiesConfiguration
{
    public class ProductionConfiguration : IEntityTypeConfiguration<Production>
    {
        public void Configure(EntityTypeBuilder<Production> builder)
        {
            builder.HasKey(x => x.Id);  // A chave primária é o Id da produção
            builder.Property(x => x.ProIdUser).IsRequired(); // Chave estrangeira para User
            builder.Property(x => x.ProIdProduct).IsRequired(); // Chave estrangeira para Product
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.MaterialCode).IsRequired();
            builder.Property(x => x.CycleTime).IsRequired();

            // Relacionamento com a entidade User
            builder.HasOne(x => x.User)
                   .WithMany(x => x.Productions) // User pode ter várias productions
                   .HasForeignKey(x => x.ProIdUser) // A chave estrangeira é ProIdUser
                   .OnDelete(DeleteBehavior.NoAction); // Mantém a integridade referencial

            // Relacionamento com a entidade Product
            builder.HasOne(x => x.Product)
                   .WithMany(x => x.Productions) // Product pode ser referenciado por várias productions
                   .HasForeignKey(x => x.ProIdProduct) // A chave estrangeira é ProIdProduct
                   .OnDelete(DeleteBehavior.NoAction); // Mantém a integridade referencial
        }
    }
}
