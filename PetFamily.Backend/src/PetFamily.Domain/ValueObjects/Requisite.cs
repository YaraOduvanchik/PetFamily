using CSharpFunctionalExtensions;

namespace PetFamily.Domain.ValueObjects;

public record Requisite
{
    public Requisite(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; } = default!;

    public string Description { get; } = default!;

    public static Result<Requisite> Create(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title))
            return Result.Failure<Requisite>("Title is empty");

        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Requisite>("Description is empty");

        return new Requisite(title, description);
    }
}