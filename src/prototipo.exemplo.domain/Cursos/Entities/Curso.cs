using Prototipo.Exemplo.Domain._Shared.Entities;
using Prototipo.Exemplo.Domain._Shared.Validations;

namespace Prototipo.Exemplo.Domain.Cursos.Entities;

public class Curso : AggregateEntity<CursoId>
{
    protected Curso()
        : base() { }

    private Curso(CursoId cursoId, string nome)
        : base(cursoId)
    {
        Nome = nome;
    }

    public string Nome { get; protected set; } = string.Empty;

    public void AtualizarInformacoes(string nome)
    {
        Nome = nome;
    }

    public static ExecutionResult<Curso> Criar(string nome)
    {
        var curso = new Curso(new CursoId(Guid.NewGuid()), nome);

        return ExecutionResult<Curso>
            .Success(curso);
    }
}
