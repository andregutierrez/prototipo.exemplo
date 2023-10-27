using Microsoft.Extensions.DependencyInjection;

namespace Prototipo.Exemplo.IoC.Extensions;
static class UseCaseExtensions
{
    public static IServiceCollection AdicionarCasosDeUso(this IServiceCollection services)
    {
        return services;
    }
}