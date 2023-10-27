using Prototipo.Exemplo.Domain._Shared.Entities;

namespace Prototipo.Exemplo.Domain.Cursos.Entities;

public class CursoId : EntityId
{
    public CursoId() { }
    public CursoId(Guid cursoId)
        : base(cursoId) { }

    public static implicit operator CursoId(Guid id)
    {
        return new CursoId(id);
    }
    public static implicit operator Guid(CursoId cursoId)
    {
        return cursoId.Id;
    }
}
