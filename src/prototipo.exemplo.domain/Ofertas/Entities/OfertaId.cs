using Prototipo.Exemplo.Domain._Shared.Entities;

namespace Prototipo.Exemplo.Domain.Ofertas.Entities;

public class OfertaId : EntityId
{
    public OfertaId() { }
    public OfertaId(Guid ofertaId)
        : base(ofertaId) { }

    public static implicit operator OfertaId(Guid id)
    {
        return new OfertaId(id);
    }
    public static implicit operator Guid(OfertaId ofertaId)
    {
        return ofertaId.Id;
    }
}
