using Prototipo.Exemplo.Domain._Shared.Entities;
using Prototipo.Exemplo.Domain._Shared.Validations;

namespace Prototipo.Exemplo.Domain.Instituicoes.Entities;

public class Instituicao : AggregateEntity<InstituicaoId>
{
    protected Instituicao()
        : base() { }

    private Instituicao(InstituicaoId entityId, string nome)
        : base(entityId)
    {
        Nome = nome;
    }

    public string Nome { get; protected set; }

    public void AtualizarInformacoes(string nome)
    {
        Nome = nome;
    }

    public static ExecutionResult<Instituicao> Criar(string nome)
    {
        var entity = new Instituicao(Guid.NewGuid(), nome);

        return ExecutionResult<Instituicao>
            .Success(entity);
    }
}
