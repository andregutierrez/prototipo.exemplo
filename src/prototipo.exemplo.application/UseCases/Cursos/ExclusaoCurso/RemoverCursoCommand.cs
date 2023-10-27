using Prototipo.Exemplo.Application._Shared.Commands;

namespace Prototipo.Exemplo.Application.UseCases.Cursos.ExclusaoCurso;


public class RemoverCursoCommand : ICommand
{
    public Guid CursoId { get; set; }
}
