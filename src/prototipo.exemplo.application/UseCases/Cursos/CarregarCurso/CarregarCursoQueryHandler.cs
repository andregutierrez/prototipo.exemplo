using Prototipo.Exemplo.Application._Shared.Queries;
using Prototipo.Exemplo.Application.DTOs.Cursos;
using Prototipo.Exemplo.Domain.Cursos;

namespace Prototipo.Exemplo.Application.UseCases.Cursos.CarregarCurso;

public class CarregarCursoQueryHandler : IQueryHandler<CarregarCursoQuery, CursoDto>
{
    public readonly ICursoRepository _cursoRepository;

    public CarregarCursoQueryHandler(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task<CursoDto> Handle(CarregarCursoQuery request, CancellationToken cancellationToken)
    {
        var query = _cursoRepository
            .GetQueryable()
            .Select(o => new CursoDto()
            {
                CursoId = o.Id,
                Nome = o.Nome
            });

        return query
            .Where(o => o.CursoId.Equals(request.CursoId))
            .Single();
    }
}
