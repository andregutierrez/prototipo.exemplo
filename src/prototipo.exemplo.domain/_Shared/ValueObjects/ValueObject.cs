namespace Prototipo.Exemplo.Domain._Shared.ValueObjects;

using System;
using System.Collections.Generic;

public abstract class ValueObject<T> : IEquatable<T> where T : ValueObject<T>
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (T)obj;
        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        int hashCode = 17;
        foreach (var component in GetEqualityComponents())
        {
            hashCode = HashCode.Combine(hashCode, component);
        }
        return hashCode;
    }

    public bool Equals(T other)
    {
        if (other == null)
        {
            return false;
        }

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
        {
            return true;
        }

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
        {
            return false;
        }

        return a.Equals(b);
    }

    public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
    {
        return !(a == b);
    }
}
