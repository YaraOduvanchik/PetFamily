using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models;

public record SocialNetwork
{
    private SocialNetwork(string title, string link)
    {
        Title = title;
        Link = link;
    }

    public string Title { get; }
    public string Link { get; }

    public static Result<SocialNetwork> Create(string title, string link)
    {
        if (string.IsNullOrWhiteSpace(title))
            return Result.Failure<SocialNetwork>("Title is empty");

        if (string.IsNullOrWhiteSpace(link))
            return Result.Failure<SocialNetwork>("Link is empty");

        return new SocialNetwork(title, link);
    }
}