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

    // ef core constructor
    private Volunteer(VolunteerId id) : base(id)
    {
    }

    private Volunteer(
        VolunteerId id,
        Fullname fullName,
        PhoneNumber phoneNumber,
        string description,
        int experienceInYears)
        : base(id)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Description = description;
        ExperienceInYears = experienceInYears;
        SocialNetworksList = new([]);
        RequisitesList = new([]);
    }

    public Fullname FullName { get; private set; } = default!;
    public PhoneNumber PhoneNumber { get; private set; } = default!;

    public string Description { get; private set; } = default!;

    public int ExperienceInYears { get; private set; }

    public ValueObjectList<SocialNetwork> SocialNetworksList { get; private set; }
    public ValueObjectList<Requisite> RequisitesList { get; private set; }

    public IReadOnlyList<Pet> Pets => _pets;

    public int CountPetsFoundHomes() => _pets.Count(p => p.HelpStatus == HelpStatus.FoundTheHouse);

    public int CountPetsLookingForHomes() => _pets.Count(p => p.HelpStatus == HelpStatus.LookingForHome);

    public int CountPetsCurrentlyTreatment() => _pets.Count(p => p.HelpStatus == HelpStatus.CurrentlyTreatment);

    public void UpdateMainInfo(
        Fullname fullName,
        PhoneNumber phoneNumber,
        string description,
        int experienceInYears)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Description = description;
        ExperienceInYears = experienceInYears;
    }

    public void UploadSocialNetworksList(ValueObjectList<SocialNetwork> socialNetworksList) =>
        SocialNetworksList = socialNetworksList;

    public void UploadRequisitesList(ValueObjectList<Requisite> requisitesList) =>
        RequisitesList = requisitesList;

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