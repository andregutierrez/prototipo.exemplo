using Microsoft.Extensions.DependencyInjection;
using Prototipo.Exemplo.Domain._Shared.Validations;

namespace Prototipo.Exemplo.IoC.Extensions;
static class ProviderExtensions
{
    public static IServiceCollection AdicionarProviderExtensions(this IServiceCollection services)
    {
        ValidatorProvider
            .Initialize(services.BuildServiceProvider());

        //        services
        //            .AddScoped<IKafkaFactory, KafkaFactory>();

        return services;
    }

}
