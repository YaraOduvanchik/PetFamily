namespace PetFamily.Domain.Shared.Ids;

public record VolunteerId
{
    private VolunteerId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static VolunteerId NewId()
    {
        return new VolunteerId(Guid.NewGuid());
    }

    public static VolunteerId Empty()
    {
        return new VolunteerId(Guid.Empty);
    }

    public static VolunteerId Create(Guid id)
    {
        return new VolunteerId(id);
    }
}