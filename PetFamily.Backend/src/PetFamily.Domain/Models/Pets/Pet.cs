﻿using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models.Pets;

public sealed class Pet : Entity<PetId>
{
    private readonly List<PetPhoto> _photos = [];
    private readonly List<Requisite> _requisites = [];

    public Pet(
        PetId id,
        string name,
        string type,
        string description,
        string breed,
        string color,
        string healthInfo,
        string address,
        double weight,
        double height,
        string phoneNumber,
        bool isCastrated,
        DateTimeOffset birthDate,
        bool isVaccine,
        string helpStatus,
        DateTimeOffset createdDate)
    : base(id)
    {
        Name = name;
        Type = type;
        Description = description;
        Breed = breed;
        Color = color;
        HealthInfo = healthInfo;
        Address = address;
        Weight = weight;
        Height = height;
        PhoneNumber = phoneNumber;
        IsCastrated = isCastrated;
        BirthDate = birthDate;
        IsVaccine = isVaccine;
        HelpStatus = helpStatus;
        CreatedDate = createdDate;
    }
    
    public string Name { get; private set; }

    public string Type { get; private set; }

    public string Description { get; private set; }

    public string Breed { get; private set; }

    public string Color { get; private set; }

    public string HealthInfo { get; private set; }

    public string Address { get; private set; }

    public double Weight { get; private set; }

    public double Height { get; private set; }

    public string PhoneNumber { get; private set; }

    public bool IsCastrated { get; private set; }

    public DateTimeOffset BirthDate { get; private set; }

    public bool IsVaccine { get; private set; }

    public string HelpStatus { get; private set; }

    public IReadOnlyList<Requisite> Requisites => _requisites;

    public IReadOnlyList<PetPhoto> Photos => _photos;

    public DateTimeOffset CreatedDate { get; private set; }
}