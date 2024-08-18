using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Entities.Specieses;

public sealed class Species : Shared.Entity<SpeciesId>
{
    private readonly List<Breed> _breeds = [];

    private Species(SpeciesId id) : base(id)
    {
    }

    private Species(SpeciesId id, string name) : base(id)
    {
        Name = name;
    }

    public string Name { get; }

    public IReadOnlyList<Breed> Breeds => _breeds;

    public static Result<Species, Error> Create(SpeciesId id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Errors.General.ValueIsInvalid("Name");

        return new Species(id, name);
    }
}