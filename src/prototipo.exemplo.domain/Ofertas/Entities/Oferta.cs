using Prototipo.Exemplo.Domain._Shared.Entities;
using Prototipo.Exemplo.Domain._Shared.Validations;
using Prototipo.Exemplo.Domain.Cursos.Entities;
using Prototipo.Exemplo.Domain.Instituicoes.Entities;

namespace Prototipo.Exemplo.Domain.Ofertas.Entities;

public class Oferta : AggregateEntity<OfertaId>
{
    protected Oferta()
        : base() { }

    private Oferta(OfertaId ofertaId, CursoId cursoId, InstituicaoId instituicaoId)
        : base(ofertaId)
    {
        CursoId = cursoId;
        InstituicaoId = instituicaoId;
    }

    public CursoId CursoId { get; protected set; } = null!;
    public InstituicaoId InstituicaoId { get; protected set; } = null!;

    public static ExecutionResult<Oferta> Criar(CursoId cursoId, InstituicaoId instituicaoId)
    {
        var oferta = new Oferta(Guid.NewGuid(), cursoId, instituicaoId);

        return ExecutionResult<Oferta>
            .Success(oferta);
    }
}
