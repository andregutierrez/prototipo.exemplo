using Prototipo.Exemplo.Application._Shared.Commands;
using Prototipo.Exemplo.Application._Shared.DTOs;

namespace Prototipo.Exemplo.Application.UseCases.Instituicoes.CriacaoInstituicao;

public class CriarInstituicaoCommand : ICommand<EntityIdDto?>
{
	public string? Nome {  get; set; }
}
