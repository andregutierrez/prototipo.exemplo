using Prototipo.Exemplo.Domain._Shared.Entities;
using Prototipo.Exemplo.Domain.Cursos.Entities;

namespace Prototipo.Exemplo.Domain.Cursos;

public interface ICursoRepository : IRepository<Curso, CursoId>
{

}