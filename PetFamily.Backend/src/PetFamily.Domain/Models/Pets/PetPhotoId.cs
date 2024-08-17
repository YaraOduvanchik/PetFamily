namespace PetFamily.Domain.Models;

public record PetPhotoId
{
    private PetPhotoId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }

    public static PetPhotoId NewId() => new(Guid.NewGuid());

    public static PetPhotoId Empty() => new(Guid.Empty);

    public static PetPhotoId Create(Guid id) => new(id);
}