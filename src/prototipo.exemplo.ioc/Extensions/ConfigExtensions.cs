using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Prototipo.Exemplo.IoC.Extensions;
static class ConfigExtensions
{
    public static IServiceCollection AdicionarConfiguracoes(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}
