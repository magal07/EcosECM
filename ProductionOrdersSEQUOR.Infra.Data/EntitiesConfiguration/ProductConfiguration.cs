using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductionOrderSEQUOR.Domain.Entities;

namespace ProductionOrderSEQUOR.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id); // Chave primária é o Id do Product
            builder.Property(x => x.ProductCode);
            builder.Property(x => x.ProductDescription).IsRequired();
            builder.Property(x => x.Image).IsRequired();
            builder.Property(x => x.CycleTime).IsRequired();

            // Se o relacionamento com Produção existir, pode ser adicionado aqui
            builder.HasMany(x => x.Productions) // Um produto pode ter várias productions
                   .WithOne(x => x.Product) // Cada produção tem um único produto
                   .HasForeignKey(x => x.ProIdProduct) // A chave estrangeira para o Product
                   .OnDelete(DeleteBehavior.NoAction); // Mantém a integridade referencial
        }
    }
}
