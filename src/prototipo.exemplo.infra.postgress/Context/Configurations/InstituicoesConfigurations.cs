using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prototipo.Exemplo.Domain.Instituicoes.Entities;

namespace Prototipo.Exemplo.Infra.Postgress.Context.Configurations;

public class InstituicoesConfigurations : IEntityTypeConfiguration<Instituicao>
{
    public void Configure(EntityTypeBuilder<Instituicao> builder)
    {
        builder.ToTable("Instituicao")
            .HasKey(c => c.Id);

        builder
            .Property(o => o.Id)
            .HasConversion(o => o.Id, value => new InstituicaoId(value))
            .HasColumnName("Id")
            .IsRequired();
    }
}

