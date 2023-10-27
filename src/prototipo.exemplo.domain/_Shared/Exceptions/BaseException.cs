using System.Runtime.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Prototipo.Exemplo.Domain._Shared.Exceptions;

/// <summary>
/// Base exception for application specific exceptions
/// </summary>
public abstract class BaseException : Exception
{
    public BaseException() { }

    public BaseException(string message)
        : base(message) { }

    public BaseException(string message, Exception? innerException)
        : base(message, innerException) { }

    public BaseException(SerializationInfo serializationInfo, StreamingContext context)
        : base(serializationInfo, context) { }
}
