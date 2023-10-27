using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prototipo.Exemplo.Domain.Ofertas.Entities;

namespace Prototipo.Exemplo.Infra.Postgress.Context.Configurations;

public class OfertasConfigurations : IEntityTypeConfiguration<Oferta>
{
    public void Configure(EntityTypeBuilder<Oferta> builder)
    {
        builder.ToTable("Oferta")
            .HasKey(c => c.Id);

        builder
            .Property(o => o.Id)
            .HasConversion(o => o.Id, value => new OfertaId(value))
            .HasColumnName("Id")
            .IsRequired();
    }
}

