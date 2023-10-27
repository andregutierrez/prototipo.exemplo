using Prototipo.Exemplo.Domain._Shared.Entities;

namespace Prototipo.Exemplo.Domain.Instituicoes.Entities;

public class InstituicaoId : EntityId
{
    public InstituicaoId() { }
    public InstituicaoId(Guid entityId)
        : base(entityId) { }

    public static implicit operator InstituicaoId(Guid id)
    {
        return new InstituicaoId(id);
    }
    public static implicit operator Guid(InstituicaoId entityId)
    {
        return entityId.Id;
    }
}
