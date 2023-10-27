using Prototipo.Exemplo.Application._Shared.Commands;

namespace Prototipo.Exemplo.Application.UseCases.Cursos.AtualizacaoCurso;


public class AtualizarCursoCommand : ICommand
{
    public Guid CursoId { get; set; }
    public string Nome { get; set; }
}
