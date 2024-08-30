using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.Ids;

namespace PetFamily.Domain.Aggregates.SpeciesesManagement;

public sealed class Species : Shared.Entity<SpeciesId>
{
    private readonly List<Breed> _breeds = [];

    // ef core constructor
    private Species(SpeciesId id) : base(id)
    {
    }

    private Species(SpeciesId id, string name) : base(id)
    {
        Name = name;
    }

    public string Name { get; private set; }

    public IReadOnlyList<Breed> Breeds => _breeds;

    public static Result<Species, Error> Create(SpeciesId id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Errors.General.ValueIsInvalid("Name");

        return new Species(id, name);
    }
}