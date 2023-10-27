using Prototipo.Exemplo.Application._Shared.Commands;
using Prototipo.Exemplo.Application._Shared.DTOs;

namespace Prototipo.Exemplo.Application.UseCases.Cursos.CriacaoCurso;

public class CriarCursoCommand : ICommand<EntityIdDto?>
{
	public string? Nome { get; set; }
}
