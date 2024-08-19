using System.Runtime.Serialization;

namespace PetFamily.Domain.Shared;

public record Error
{
    private const string Separator = "||";
    
    public string Code { get; }

    public string Message { get; }

    public ErrorType Type { get; }
    
    private Error(string code, string message, ErrorType type)
    {
        Code = code;
        Message = message;
        Type = type;
    }
    
    public string Serialize()
    {
        return $"{Code}{Separator}{Message}{Separator}{Type}";
    }

    public static Error Deserialize(string serialized)
    {
        var data = serialized.Split([Separator], StringSplitOptions.RemoveEmptyEntries);

        if (data.Length < 3)
            throw new($"Invalid error serialization: '{serialized}'");

        if (Enum.TryParse(data[2], out ErrorType type) == false)
            throw new($"Invalid error serialization: '{serialized}'");
        
        return new(data[0], data[1], type);
    }

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