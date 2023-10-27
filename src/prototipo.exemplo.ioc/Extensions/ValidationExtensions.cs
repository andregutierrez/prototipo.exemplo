using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Prototipo.Exemplo.IoC.Extensions;
static class ValidationExtensions
{
    public static IServiceCollection AdicionarValidadoresDoDominio(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AdicionarValidadoresDaAplicacao(this IServiceCollection services)
    {
        return services;
    }
}