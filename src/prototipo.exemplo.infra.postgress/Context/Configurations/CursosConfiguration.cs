using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prototipo.Exemplo.Domain.Cursos.Entities;

namespace Prototipo.Exemplo.Infra.Postgress.Context.Configurations;

public class CursosConfiguration : IEntityTypeConfiguration<Curso>
{
    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.ToTable("Curso")
            .HasKey(c => c.Id);

        builder
            .Property(o => o.Id)
            .HasConversion(o => o.Id, value => new CursoId(value))
            .HasColumnName("Id")
            .IsRequired();
    }
}

