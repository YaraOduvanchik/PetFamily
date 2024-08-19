using PetFamily.Domain.Shared;
using PetFamily.Domain.ValueObjects;

namespace PetFamily.Domain.Entities.Pets;

public sealed class Pet : Entity<PetId>
{
    private readonly List<PetPhoto> _photos = [];
    private readonly List<Requisite> _requisites = [];

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

    public string Name { get; private set; }
    public string Type { get; private set; }
    public string Description { get; private set; }
    public string Color { get; private set; }
    public string HealthInfo { get; private set; }

    public double Weight { get; private set; }
    public double Height { get; private set; }

    public bool IsCastrated { get; private set; }
    public bool IsVaccine { get; private set; }

    public Address Address { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public HelpStatus HelpStatus { get; private set; }
    public PetDetails PetDetails { get; private set; }

    public DateTimeOffset BirthDate { get; private set; }
    public DateTimeOffset CreatedDate { get; private set; }

    public IReadOnlyList<Requisite> Requisites => _requisites;
    public IReadOnlyList<PetPhoto> Photos => _photos;
}