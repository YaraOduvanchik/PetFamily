namespace PetFamily.Domain.Shared;

public record Error
{
    private Error(string code, string messege, ErrorType type)
    {
        Code = code;
        Messege = messege;
        Type = type;
    }

    public string Code { get; }

    public string Messege { get; }

    public ErrorType Type { get; }

    public static Error Validation(string code, string message)
    {
        return new Error(code, message, ErrorType.Validation);
    }

    public static Error NotFound(string code, string message)
    {
        return new Error(code, message, ErrorType.NotFound);
    }

    public static Error Failure(string code, string message)
    {
        return new Error(code, message, ErrorType.Failure);
    }

    public static Error Conflict(string code, string message)
    {
        return new Error(code, message, ErrorType.Conflict);
    }
}

public enum ErrorType
{
    Validation,
    NotFound,
    Failure,
    Conflict
}