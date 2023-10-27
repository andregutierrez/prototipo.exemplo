using Prototipo.Exemplo.Application._Shared.Queries;
using Prototipo.Exemplo.Application.DTOs.Cursos;
using Prototipo.Exemplo.Domain.Cursos;

namespace Prototipo.Exemplo.Application.UseCases.Cursos.PesquisarCurso;

public class PesquisarCursoQueryHandler : IQueryHandler<PesquisarCursoQuery, IEnumerable<CursoDto>>
{
    public readonly ICursoRepository _cursoRepository;

    public PesquisarCursoQueryHandler(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task<IEnumerable<CursoDto>> Handle(PesquisarCursoQuery request, CancellationToken cancellationToken)
    {
        var query = _cursoRepository
            .GetQueryable()
            .Select(o => new CursoDto() { 
                CursoId = o.Id,
                Nome = o.Nome
            });

        return query
            .ToList();
    }
}

