using PetFamily.Domain.Entities.Pets;
using PetFamily.Domain.Shared;
using PetFamily.Domain.ValueObjects;

namespace PetFamily.Domain.Entities.Volunteers;

public sealed class Volunteer : Entity<VolunteerId>
{
    private readonly List<Pet> _pets = [];
    private readonly List<Requisite> _requisites = [];
    private readonly List<SocialNetwork> _socialNetworks = [];

    public Volunteer(VolunteerId id) : base(id)
    {
    }

    public Fullname FullName { get; private set; }

    public string Descriptions { get; private set; }

    public int ExperienceInYears { get; private set; }

    public PhoneNumber PhoneNumber { get; private set; }

    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;

    public IReadOnlyList<Requisite> Requisites => _requisites;

    public IReadOnlyList<Pet> Pets => _pets;

    public int CountPetsFoundHomes() => _pets.Count(p => p.HelpStatus == HelpStatus.FoundTheHouse);

    public int CountPetsLookingForHomes() => _pets.Count(p => p.HelpStatus == HelpStatus.LookingForHome);

    public int CountPetsCurrentlyTreatment() => _pets.Count(p => p.HelpStatus == HelpStatus.CurrentlyTreatment);
}