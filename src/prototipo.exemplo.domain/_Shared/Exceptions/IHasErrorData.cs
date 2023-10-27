using System.Collections;

namespace Prototipo.Exemplo.Domain._Shared.Exceptions;

public interface IHasErrorData
{
    public IDictionary Data { get; }
}
