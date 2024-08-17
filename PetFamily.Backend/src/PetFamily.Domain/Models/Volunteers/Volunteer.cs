namespace PetFamily.Domain.Models;

public class Volunteer
{
    public Volunteer(
        Guid id, 
        string fullName, 
        string descriptions, 
        int experienceInYears,
        string phoneNumber)
    {
        Id = id;
        FullName = fullName;
        Descriptions = descriptions;
        ExperienceInYears = experienceInYears;
        PhoneNumber = phoneNumber;
    }

    public Guid Id { get; private set; }
    
    public string FullName { get; private set; }
    
    public string Descriptions { get; private set; }
    
    public int ExperienceInYears { get; private set; }

    public string PhoneNumber { get; private set; }

    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;
    private List<SocialNetwork> _socialNetworks = [];
    
    public IReadOnlyList<Requisite> Requisites => _requisites;
    private List<Requisite> _requisites = [];
    
    public IReadOnlyList<Pet> Pets => _pets;
    private List<Pet> _pets = [];
    
    public int CountPetsFoundHomes() => 0;

    public int CountPetsLookingForHomes() => 0;
    
    public int CountPetsCurrentlyTreatment() => 0;
}