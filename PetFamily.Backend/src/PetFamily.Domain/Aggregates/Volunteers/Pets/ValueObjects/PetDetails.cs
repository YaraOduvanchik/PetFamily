using PetFamily.Domain.Shared.Ids;

namespace PetFamily.Domain.Aggregates.Volunteers.Pets.ValueObjects;

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