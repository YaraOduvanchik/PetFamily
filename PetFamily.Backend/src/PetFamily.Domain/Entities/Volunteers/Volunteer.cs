using CSharpFunctionalExtensions;
using PetFamily.Domain.Entities.Pets;
using PetFamily.Domain.Shared;
using PetFamily.Domain.ValueObjects;

namespace PetFamily.Domain.Entities.Volunteers;

public sealed class Volunteer : Shared.Entity<VolunteerId>
{
    private readonly List<Pet> _pets = [];
    private readonly List<Requisite> _requisites = [];
    private readonly List<SocialNetwork> _socialNetworks = [];

    private Volunteer(VolunteerId id) : base(id)
    {
    }

    private Volunteer(
        VolunteerId id,
        Fullname fullName,
        PhoneNumber phoneNumber,
        string descriptions,
        int experienceInYears) 
        : base(id)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Descriptions = descriptions;
        ExperienceInYears = experienceInYears;
    }

    public Fullname FullName { get; }
    public PhoneNumber PhoneNumber { get; }

    public string Descriptions { get; }

    public int ExperienceInYears { get; }

    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;
    public IReadOnlyList<Requisite> Requisites => _requisites;
    public IReadOnlyList<Pet> Pets => _pets;

    public int CountPetsFoundHomes() => _pets.Count(p => p.HelpStatus == HelpStatus.FoundTheHouse);

    public int CountPetsLookingForHomes() => _pets.Count(p => p.HelpStatus == HelpStatus.LookingForHome);

    public int CountPetsCurrentlyTreatment() => _pets.Count(p => p.HelpStatus == HelpStatus.CurrentlyTreatment);

    public static Result<Volunteer, Error> Create(
        VolunteerId id,
        Fullname fullName,
        PhoneNumber phoneNumber,
        string descriptions,
        int experienceInYears)
    {
        if (string.IsNullOrWhiteSpace(descriptions))
            return Errors.General.ValueIsInvalid("Descriptions");

        if (experienceInYears <= 0)
            return Errors.General.ValueIsInvalid("Experience in years");

        return new Volunteer(id, fullName, phoneNumber, descriptions, experienceInYears);
    }
}