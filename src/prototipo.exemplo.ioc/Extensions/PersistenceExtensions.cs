using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prototipo.Exemplo.Domain._Shared.Entities;
using Prototipo.Exemplo.Domain.Cursos;
using Prototipo.Exemplo.Domain.Instituicoes;
using Prototipo.Exemplo.Domain.Ofertas;
using Prototipo.Exemplo.Infra.Postgress.Context;
using Prototipo.Exemplo.Infra.Postgress.Repositories;

namespace Prototipo.Exemplo.IoC.Extensions;
static class PersistenceExtensions
{
    public static IServiceCollection AdicionarContextoDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ExemploDbContext>(options =>
            options.UseInMemoryDatabase("InMemoryExemplo"));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        

        return services;
    }

    public static IServiceCollection AdicionarRepositorios(this IServiceCollection services)
    {
        services.AddScoped<ICursoRepository, CursoRepository>();
        services.AddScoped<IInstituicaoRepository, InstituicaoRepository>();
        services.AddScoped<IOfertaRepository, OfertaRepository>();

        return services;
    }

    public static IServiceCollection AdicionarConexaoDbFactory(this IServiceCollection services)
    {
        //services.AddScoped<IUnitOfWork, UnitOfWorkPortifolios>();
        // services.AddScoped<IConexaoDbFactory, ConexaoDbFactory>();
        // services.AddScoped<ITransactionManager, TransactionManager>();
        return services;
    }
}