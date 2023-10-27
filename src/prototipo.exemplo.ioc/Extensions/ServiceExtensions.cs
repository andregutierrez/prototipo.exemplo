using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Prototipo.Exemplo.IoC.Extensions;
static class ServiceExtensions
{
    public static IServiceCollection AdicionarServicosExternos(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddScoped<IKafkaService, KafkaService>();
        return services;
    }
}
