using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Prototipo.Exemplo.Application._Shared.DTOs;
using Prototipo.Exemplo.Application.UseCases.Cursos.CriacaoCurso;
using Prototipo.Exemplo.Domain._Shared.Entities;

namespace Prototipo.Exemplo.IoC.Extensions;
static class ValidationExtensions
{
    public static IServiceCollection AdicionarValidadoresDoDominio(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AdicionarValidadoresDaAplicacao(this IServiceCollection services)
    {
        services.AddScoped<IPipelineBehavior<CriarCursoCommand, EntityIdDto?>, CriarCursoCommandValidator>();
        return services;
    }
}