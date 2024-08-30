using CSharpFunctionalExtensions;
using PetFamily.Domain.Aggregates.PetsManagement.Pets;
using PetFamily.Domain.Aggregates.PetsManagement.Pets.ValueObjects;
using PetFamily.Domain.Aggregates.PetsManagement.ValueObjects;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.Ids;
using PetFamily.Domain.Shared.ValueObjects;

namespace PetFamily.Domain.Aggregates.PetsManagement.AggregateRoot;

public sealed class Volunteer : Shared.Entity<VolunteerId>
{
    private readonly List<Pet> _pets = [];
    private readonly List<Requisite> _requisites = [];
    private readonly List<SocialNetwork> _socialNetworks = [];

    // ef core constructor
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

    public Fullname FullName { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }

    public string Descriptions { get; private set; }

    public int ExperienceInYears { get; private set; }

    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;
    public IReadOnlyList<Requisite> Requisites => _requisites;
    public IReadOnlyList<Pet> Pets => _pets;

    public int CountPetsFoundHomes() => _pets.Count(p => p.HelpStatus == HelpStatus.FoundTheHouse);

    public int CountPetsLookingForHomes() => _pets.Count(p => p.HelpStatus == HelpStatus.LookingForHome);

    public int CountPetsCurrentlyTreatment() => _pets.Count(p => p.HelpStatus == HelpStatus.CurrentlyTreatment);

    public Result AddSocialNetwork(SocialNetwork socialNetwork)
    {
        // ToDo сделать проверки

        _socialNetworks.Add(socialNetwork);

        return Result.Success();
    }

    public Result AddRequisite(Requisite requisite)
    {
        // ToDo сделать проверки

        _requisites.Add(requisite);

        return Result.Success();
    }

    public Result AddPet(Pet pet)
    {
        // ToDo сделать проверки

        _pets.Add(pet);

        return Result.Success();
    }

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