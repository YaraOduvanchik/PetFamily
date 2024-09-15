using CSharpFunctionalExtensions;
using PetFamily.Domain.Aggregates.PetsManagement.ValueObjects;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.Ids;
using PetFamily.Domain.Shared.ValueObjects;

namespace PetFamily.Domain.Aggregates.PetsManagement.Pets;

public sealed class Pet : Shared.Entity<PetId>, ISoftDeletable
{
    private readonly List<PetPhoto> _photos = [];
    private bool _isDelete = false;

    // ef core constructor
    private Pet(PetId Id)
        : base(Id)
    {
    }

    public Pet(
        PetId id,
        string name,
        string type,
        string description,
        string color,
        string healthInfo,
        double weight,
        double height,
        bool isCastrated,
        bool isVaccine,
        Address address,
        PhoneNumber phoneNumber,
        HelpStatus helpStatus,
        PetDetails petDetails,
        DateTimeOffset birthDate)
        : base(id)
    {
        Name = name;
        Type = type;
        Description = description;
        Color = color;
        HealthInfo = healthInfo;
        Weight = weight;
        Height = height;
        IsCastrated = isCastrated;
        IsVaccine = isVaccine;
        Address = address;
        PhoneNumber = phoneNumber;
        HelpStatus = helpStatus;
        PetDetails = petDetails;
        BirthDate = birthDate;
        CreatedDate = DateTimeOffset.Now;
    }

    public string Name { get; private set; } = default!;
    public string Type { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public string Color { get; private set; } = default!;
    public string HealthInfo { get; private set; } = default!;

    public double Weight { get; private set; }
    public double Height { get; private set; }

    public bool IsCastrated { get; private set; }
    public bool IsVaccine { get; private set; }

    public Address Address { get; private set; } = default!;
    public PhoneNumber PhoneNumber { get; private set; } = default!;
    public HelpStatus HelpStatus { get; private set; } = default!;
    public PetDetails PetDetails { get; private set; } = default!;

    public DateTimeOffset BirthDate { get; private set; }
    public DateTimeOffset CreatedDate { get; private set; }

    public ValueObjectList<Requisite> RequisitesList { get; private set; }
    public IReadOnlyList<PetPhoto> Photos => _photos;
    
    public void Delete()
    {
        if (_isDelete == false)
        {
            _isDelete = true;
        }
    }

    public void Restore()
    {
        if (_isDelete)
        {
            _isDelete = false;
        }
    }

    public static Result<Pet, Error> Create(
        PetId id,
        string name,
        string type,
        string description,
        string color,
        string healthInfo,
        double weight,
        double height,
        bool isCastrated,
        bool isVaccine,
        Address address,
        PhoneNumber phoneNumber,
        HelpStatus helpStatus,
        PetDetails petDetails,
        DateTimeOffset birthDate)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Errors.General.ValueIsInvalid("name");
        
        if (string.IsNullOrWhiteSpace(type))
            return Errors.General.ValueIsInvalid("type");
        
        if (string.IsNullOrWhiteSpace(description))
            return Errors.General.ValueIsInvalid("description");
        
        if (string.IsNullOrWhiteSpace(color))
            return Errors.General.ValueIsInvalid("color");
        
        if (string.IsNullOrWhiteSpace(healthInfo))
            return Errors.General.ValueIsInvalid("healthInfo");
        
        if (weight <= 0)
            return Errors.General.ValueIsInvalid("weight");
        
        if (height < 0)
            return Errors.General.ValueIsInvalid("height");
        
        if (string.IsNullOrWhiteSpace(healthInfo))
            return Errors.General.ValueIsInvalid("healthInfo");

        return new Pet(
            id,
            name,
            type,
            description,
            color,
            healthInfo,
            weight,
            height,
            isCastrated,
            isVaccine,
            address,
            phoneNumber,
            helpStatus,
            petDetails,
            birthDate);
    }
}