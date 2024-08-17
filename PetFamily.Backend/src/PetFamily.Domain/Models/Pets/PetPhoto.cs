using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models;

public sealed class PetPhoto
{
    private PetPhoto(PetPhotoId id, string path, bool isMain)
    {
        Id = id;
        Path = path;
        IsMain = isMain;
    }

    public PetPhotoId Id { get; private set; }
    
    public string Path { get; private set; }
    
    public bool IsMain { get; private set; }

    public static Result<PetPhoto, Error> Create(PetPhotoId id, string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return Errors.General.ValueIsInvalid("Path");

        return new PetPhoto(id, path, false);
    }
    
    public static Result<PetPhoto, Error> CreateMain(PetPhotoId id, string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return Errors.General.ValueIsInvalid("Path");

        return new PetPhoto(id, path, true);
    }
}