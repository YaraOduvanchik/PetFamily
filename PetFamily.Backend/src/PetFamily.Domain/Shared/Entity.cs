namespace PetFamily.Domain.Shared;

public abstract class Entity<TId>
    where TId : notnull
{
    public TId Id { get; }

    protected Entity(TId id)
    {
        Id = id;
    }

    public static bool operator ==(Entity<TId>? first, Entity<TId>? second)
    {
        if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
            return true;

        if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            return false;

        return first.Equals(second);
    }

    public static bool operator !=(Entity<TId>? first, Entity<TId>? second)
    {
        return !(first == second);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TId> other)
            return false;

        if (ReferenceEquals(this, other) == false)
            return false;

        if (GetType() != other.GetType())
            return false;

        return ReferenceEquals(this, other) || Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return (GetType().FullName + Id).GetHashCode();
    }
}