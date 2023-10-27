using Prototipo.Exemplo.Application.UseCases.Cursos.CriacaoCurso;
using System.Reflection;

namespace Prototipo.Exemplo.IoC;

public static class Assemblies
{
    public static readonly Assembly Application = typeof(CriarCursoCommand).Assembly;
}