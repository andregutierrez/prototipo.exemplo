using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prototipo.Exemplo.Domain._Shared.Notifications;
using Prototipo.Exemplo.IoC.Extensions;

namespace Prototipo.Exemplo.IoC;


public static class RegistrationDependencyExtensions
{
    public static void RegistrarServicos(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assemblies.Application));

        services
            .AddScoped<INotificationContext, NotificationContext>();

        services.AddSingleton(configuration)
            .AdicionarCache(configuration)
            .AdicionarContextoDb(configuration)
            .AdicionarConexaoDbFactory()
            .AdicionarRepositorios()
            .AdicionarValidadoresDaAplicacao()
            .AdicionarValidadoresDoDominio()
            .AdicionarCasosDeUso()
            .AdicionarProviderExtensions()
            .AdicionarConfiguracoes(configuration)
            .AdicionarServicosExternos(configuration);
    }
}