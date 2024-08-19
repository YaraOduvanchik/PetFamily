using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.ValueObjects;

public record PhoneNumber
{
    private const string REGEX_RUSSIAN_PHONE_NUMBER =
        @"^(?:\+?7|8)?(?:[\s\-(_]+)?(\d{3})(?:[\s\-_)]+)?(\d{3})(?:[\s\-_]+)?(\d{2})(?:[\s\-_]+)?(\d{2})$";

    private PhoneNumber(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<PhoneNumber, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) && Regex.IsMatch(value, REGEX_RUSSIAN_PHONE_NUMBER) == false)
            return Errors.General.ValueIsInvalid("Phone Number");

        return new PhoneNumber(value);
    }
}