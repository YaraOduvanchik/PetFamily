using CSharpFunctionalExtensions;
using PetFamily.Domain.Entities.Specieses;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.ValueObjects;

public record PetDetails
{
    public PetDetails(SpeciesId speciesId, BreedId breedId)
    {
        SpeciesId = speciesId;
        BreedId = breedId;
    }

    public SpeciesId SpeciesId { get; }
    public BreedId BreedId { get; }
}