namespace PetFamily.Domain.Entities.Pets;

public record PetPhotoId
{
    private PetPhotoId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static PetPhotoId NewId()
    {
        return new PetPhotoId(Guid.NewGuid());
    }

    public static PetPhotoId Empty()
    {
        return new PetPhotoId(Guid.Empty);
    }

    public static PetPhotoId Create(Guid id)
    {
        return new PetPhotoId(id);
    }
}