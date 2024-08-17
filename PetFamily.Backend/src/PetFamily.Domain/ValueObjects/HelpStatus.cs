using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.ValueObjects;

public record HelpStatus
{
    public static readonly HelpStatus CurrentlyTreatment = new(nameof(CurrentlyTreatment));
    public static readonly HelpStatus LookingForHome = new(nameof(LookingForHome));
    public static readonly HelpStatus FoundTheHouse = new(nameof(FoundTheHouse));

    private static readonly List<HelpStatus> _helpStatuses = [CurrentlyTreatment, LookingForHome, FoundTheHouse];

    private HelpStatus(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<HelpStatus, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.General.ValueIsInvalid("Help Status");

        var helpStatus = value.Trim().ToLower();

        if (_helpStatuses.Any(hs => hs.Value.ToLower() == helpStatus) == false) 
            throw new ArgumentException();

        return new HelpStatus(value);
    }
}