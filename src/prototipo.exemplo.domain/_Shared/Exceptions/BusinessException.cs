using System.Net;
using System.Runtime.Serialization;
using Microsoft.Extensions.Logging;

namespace Prototipo.Exemplo.Domain._Shared.Exceptions;

/// <summary>
/// Base exception for business specific exceptions
/// </summary>
[Serializable]
public class BusinessException : BaseException, IHasHttpCode
{
    /// <summary>
    /// Bussiness code for the exception
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Informa como a excessão deverá ser tratada pelo log da aplicação
    /// </summary>
    public LogLevel LogLevel { get; set; }

    /// <summary>
    /// Detail code for the exception informing which business rule was not respected
    /// </summary>
    public string Details { get; set; } = string.Empty;

    public HttpStatusCode StatusCode => HttpStatusCode.UnprocessableEntity;

    public BusinessException()
        : base("Business Exception")
    { }

    public BusinessException(string code)
        : base("Business Exception")
    {
        Code = code;
    }

    public BusinessException(string message, string code)
    : base(message)
    {
        Code = code;
    }

    public BusinessException(string message, string code, string details)
    : base(message)
    {
        Code = code;
        Details = details;
    }

    public BusinessException(string message, string code, string details, Exception innerException)
        : base(message, innerException)
    {
        Code = code;
        Details = details;
    }

    public BusinessException(string message, string code, string details, Exception innerException, LogLevel logLevel)
        : base(message, innerException)
    {
        Code = code;
        Details = details;
        LogLevel = logLevel;
    }

    public BusinessException(SerializationInfo serializationInfo, StreamingContext context)
        : base(serializationInfo, context) { }

    /// <summary>
    ///  Allows inserting informative data about the exception
    /// </summary>
    public BusinessException WithData(string name, object value)
    {
        Data[name] = value;
        return this;
    }
}
