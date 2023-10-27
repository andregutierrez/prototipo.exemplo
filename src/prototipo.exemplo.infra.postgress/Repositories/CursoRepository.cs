using Microsoft.EntityFrameworkCore;
using Prototipo.Exemplo.Domain.Cursos;
using Prototipo.Exemplo.Domain.Cursos.Entities;
using Prototipo.Exemplo.Infra.Postgress._Shared.Repositories;
using Prototipo.Exemplo.Infra.Postgress.Context;

namespace Prototipo.Exemplo.Infra.Postgress.Repositories;

public class CursoRepository : BaseRepository<Curso, CursoId>, ICursoRepository
{
    public CursoRepository(ExemploDbContext dbContext)
        : base(dbContext) { }
}

