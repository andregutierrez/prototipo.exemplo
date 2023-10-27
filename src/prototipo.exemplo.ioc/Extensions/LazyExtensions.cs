using Microsoft.Extensions.DependencyInjection;

namespace Prototipo.Exemplo.IoC.Extensions;

static class LazyExtensions
{
    public static void AdicionarLazyLoading(this IServiceCollection services)
    {
        var numeroServicos = services.Count;

        for (int i = 0; i < numeroServicos; i++)
        {
            var servico = services[i];
            AdicionarLazyLoadingServico(services, servico);
        }
    }

    public static void ComLazyLoading(this IServiceCollection services)
    {
        var servico = services.Last();
        AdicionarLazyLoadingServico(services, servico);
    }

    private static void AdicionarLazyLoadingServico(IServiceCollection services, ServiceDescriptor servicoOriginal)
    {
        var lazyServiceType = typeof(Lazy<>).MakeGenericType(servicoOriginal.ServiceType);
        var lazyServiceImplementationType = typeof(LazyService<>).MakeGenericType(servicoOriginal.ServiceType);

        services.Add(new ServiceDescriptor(lazyServiceType, lazyServiceImplementationType, servicoOriginal.Lifetime));
    }

    private sealed class LazyService<T> : Lazy<T>
        where T : notnull
    {
        public LazyService(IServiceScopeFactory scopeFactory)
            : base(() =>
            {
                var scope = scopeFactory.CreateScope();
                return scope.ServiceProvider.GetRequiredService<T>();
            })
        {
        }
    }
}