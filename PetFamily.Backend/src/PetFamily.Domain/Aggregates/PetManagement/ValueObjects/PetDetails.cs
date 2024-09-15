using PetFamily.Domain.Shared.Ids;

namespace PetFamily.Domain.Aggregates.PetsManagement.ValueObjects;

public record PetDetails
{
    public PetDetails(SpeciesId speciesId, Guid breedId)
    {
        SpeciesId = speciesId;
        BreedId = breedId;
    }

    public SpeciesId SpeciesId { get; }
    public Guid BreedId { get; }
}