using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.Ids;

namespace PetFamily.Domain.Aggregates.PetsManagement.Pets;

public sealed class PetPhoto : Shared.Entity<PetPhotoId>, ISoftDeletable
{
    private bool _isDelete = false;
    
    private PetPhoto(PetPhotoId id, string path, bool isMain)
        : base(id)
    {
        Path = path;
        IsMain = isMain;
    }

    public string Path { get; private set; }

    public bool IsMain { get; private set; }

    public void Delete()
    {
        if (_isDelete == false)
        {
            _isDelete = true;
        }
    }

    public void Restore()
    {
        if (_isDelete)
        {
            _isDelete = false;
        }
    }
    
    public static Result<PetPhoto, Error> Create(PetPhotoId id, string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return Errors.General.ValueIsInvalid("Path");

        return new PetPhoto(id, path, false);
    }

    public static Result<PetPhoto, Error> CreateIsMain(PetPhotoId id, string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return Errors.General.ValueIsInvalid("Path");

        return new PetPhoto(id, path, true);
    }
}