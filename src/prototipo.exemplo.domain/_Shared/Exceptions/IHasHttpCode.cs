using System.Net;

namespace Prototipo.Exemplo.Domain._Shared.Exceptions;

public interface IHasHttpCode
{
    public HttpStatusCode StatusCode { get; }
}
