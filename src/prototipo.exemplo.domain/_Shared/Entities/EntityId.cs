namespace Prototipo.Exemplo.Domain._Shared.Entities;

public class EntityId : IEquatable<EntityId>
{
    public EntityId(Guid id)
    {
        Id = id;
    }

    protected EntityId()
    {
    }

    public Guid Id { get; protected set; }

    public bool Equals(EntityId other)
    {
        if (other == null)
            return false;

        return Id.Equals(other.Id);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is EntityId))
            return false;

        return Equals((EntityId)obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
