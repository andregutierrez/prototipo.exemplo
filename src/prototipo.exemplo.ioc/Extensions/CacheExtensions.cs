using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Prototipo.Exemplo.IoC.Extensions;

static class CacheExtensions
{
    public static IServiceCollection AdicionarCache(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    private static void ConfigurarCacheDistribuido(this IServiceCollection services, IConfiguration configuration)
    {
    }

    private static void ConfigurarCacheMemoria(this IServiceCollection services)
    {
    }
}
