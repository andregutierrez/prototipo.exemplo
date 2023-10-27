using MediatR;

namespace Prototipo.Exemplo.Application._Shared.Queries;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}

