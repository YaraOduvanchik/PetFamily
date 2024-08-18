using PetFamily.Domain.Models.Pets;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models.Volunteers;

public sealed class Volunteer : Entity<VolunteerId>
{
    private readonly List<Pet> _pets = [];
    private readonly List<Requisite> _requisites = [];
    private readonly List<SocialNetwork> _socialNetworks = [];

    public Volunteer(
        VolunteerId id,
        string fullName,
        string descriptions,
        int experienceInYears,
        string phoneNumber)
        : base(id)
    {
        FullName = fullName;
        Descriptions = descriptions;
        ExperienceInYears = experienceInYears;
        PhoneNumber = phoneNumber;
    }

    public string FullName { get; private set; }

    public string Descriptions { get; private set; }

    public int ExperienceInYears { get; private set; }

    public string PhoneNumber { get; private set; }

    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;

    public IReadOnlyList<Requisite> Requisites => _requisites;

    public IReadOnlyList<Pet> Pets => _pets;

    public int CountPetsFoundHomes()
    {
        return 0;
    }

    public int CountPetsLookingForHomes()
    {
        return 0;
    }

    public int CountPetsCurrentlyTreatment()
    {
        return 0;
    }
}