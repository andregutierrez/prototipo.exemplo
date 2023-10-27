using Prototipo.Exemplo.Domain._Shared.Entities;

namespace Prototipo.Exemplo.Application._Shared.DTOs;

public class EntityIdDto
{
    public Guid Id { get; set; }

    public static implicit operator EntityIdDto(EntityId id)
        => new EntityIdDto() { Id = id.Id };
}