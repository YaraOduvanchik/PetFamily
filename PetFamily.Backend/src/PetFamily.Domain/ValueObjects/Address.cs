using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.ValueObjects;

public record Address
{
    private Address(string country, string city, string street, string house)
    {
        Country = country;
        City = city;
        Street = street;
        House = house;
    }

    public string Country { get; }
    public string City { get; }
    public string Street { get; }
    public string House { get; }

    public static Result<Address, Error> Create(string country, string city, string street, string house)
    {
        if (string.IsNullOrWhiteSpace(country))
            return Errors.General.ValueIsInvalid("Country");

        if (string.IsNullOrWhiteSpace(city))
            return Errors.General.ValueIsInvalid("City");

        if (string.IsNullOrWhiteSpace(street))
            return Errors.General.ValueIsInvalid("Street");

        if (string.IsNullOrWhiteSpace(house))
            return Errors.General.ValueIsInvalid("House");

        return new Address(country, city, street, house);
    }
}