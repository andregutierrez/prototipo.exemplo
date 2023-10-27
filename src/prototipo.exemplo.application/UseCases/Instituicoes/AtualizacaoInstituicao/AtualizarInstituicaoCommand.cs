using Prototipo.Exemplo.Application._Shared.Commands;

namespace Prototipo.Exemplo.Application.UseCases.Instituicoes.AtualizacaoInstituicao;


public class AtualizarInstituicaoCommand : ICommand
{
    public Guid InstituicaoId { get; set; }
    public string? Nome { get; set; }
}
