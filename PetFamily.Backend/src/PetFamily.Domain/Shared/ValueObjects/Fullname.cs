using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared.ValueObjects;

public record Fullname
{
    private Fullname(string name, string surname, string patronymic)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
    }

    public string Name { get; }
    public string Surname { get; }
    public string Patronymic { get; }

    public static Result<Fullname, Error> Create(string name, string surname, string patronymic)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Errors.General.ValueIsInvalid("Name");

        if (string.IsNullOrWhiteSpace(surname))
            return Errors.General.ValueIsInvalid("Surname");

        if (string.IsNullOrWhiteSpace(patronymic))
            return Errors.General.ValueIsInvalid("Patronymic");

        return new Fullname(name, surname, patronymic);
    }
}