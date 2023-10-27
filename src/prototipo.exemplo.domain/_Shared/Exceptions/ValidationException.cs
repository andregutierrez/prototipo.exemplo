namespace Prototipo.Exemplo.Domain._Shared.Exceptions;

public class ValidationException
{
    public ValidationException(string message, string[] members)
    {
        Message = message;
        Members = members;
    }

    /// <summary>
    /// Error message.
    /// </summary>
    public string Message { get; protected set; } = string.Empty;

    /// <summary>
    /// The member names that caused the validation error.
    /// </summary>
    public string[] Members { get; protected set; } = new string[0];

}