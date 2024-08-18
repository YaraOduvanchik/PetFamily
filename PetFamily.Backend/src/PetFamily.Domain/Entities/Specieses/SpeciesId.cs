namespace PetFamily.Domain.Entities.Specieses;

public record SpeciesId
{
    private SpeciesId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static SpeciesId NewId()
    {
        return new SpeciesId(Guid.NewGuid());
    }

    public static SpeciesId Empty()
    {
        return new SpeciesId(Guid.Empty);
    }

    public static SpeciesId Create(Guid id)
    {
        return new SpeciesId(id);
    }
}