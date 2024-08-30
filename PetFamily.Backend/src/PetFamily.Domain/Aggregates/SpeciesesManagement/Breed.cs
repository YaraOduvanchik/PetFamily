using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.Ids;

namespace PetFamily.Domain.Aggregates.SpeciesesManagement;

public sealed class Breed : Shared.Entity<BreedId>
{
    // ef core constructor
    private Breed(BreedId id) : base(id)
    {
    }

    private Breed(BreedId id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public static Result<Breed, Error> Create(
        BreedId id, string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Errors.General.ValueIsInvalid("Name");

        if (string.IsNullOrWhiteSpace(description))
            return Errors.General.ValueIsInvalid("Description");

        return new Breed(id, name, description);
    }
}