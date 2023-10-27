using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Prototipo.Exemplo.Domain.Cursos.Entities;
using Prototipo.Exemplo.Domain.Instituicoes.Entities;
using Prototipo.Exemplo.Domain.Ofertas.Entities;
using Prototipo.Exemplo.Infra.Postgress._Shared.Context;
using Techleap.Oficinas.Infra.Data.Postgress.Context.Configurations;

namespace Prototipo.Exemplo.Infra.Postgress.Context;

public class ExemploDbContext : CoreDbContext
{
    public ExemploDbContext(DbContextOptions options, IMediator mediator) 
        : base(options, mediator) { }

    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Instituicao> Instituicoes { get; set; }
    public DbSet<Oferta> Ofertas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CursosConfiguration());
        modelBuilder.ApplyConfiguration(new InstituicoesConfigurations());
        modelBuilder.ApplyConfiguration(new OfertasConfigurations());

        base.OnModelCreating(modelBuilder);
    }
}
