namespace PetFamily.Domain.Shared.Ids;

public record PetPhotoId
{
    private PetPhotoId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static PetPhotoId NewId() => new(Guid.NewGuid());

    public static PetPhotoId Empty() => new(Guid.Empty);

    public static PetPhotoId Create(Guid id) => new(id);

    public static implicit operator PetPhotoId(Guid id) => new(id);

    public static implicit operator Guid(PetPhotoId petPhotoId)
    {
        ArgumentNullException.ThrowIfNull(petPhotoId);
        return petPhotoId.Value;
    }
}