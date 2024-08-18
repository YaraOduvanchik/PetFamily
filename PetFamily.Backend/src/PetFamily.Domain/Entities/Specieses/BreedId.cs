namespace PetFamily.Domain.Entities.Specieses;

public record BreedId
{
    private BreedId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static BreedId NewId()
    {
        return new BreedId(Guid.NewGuid());
    }

    public static BreedId Empty()
    {
        return new BreedId(Guid.Empty);
    }

    public static BreedId Create(Guid id)
    {
        return new BreedId(id);
    }
}