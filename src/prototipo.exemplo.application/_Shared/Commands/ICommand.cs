using MediatR;

namespace Prototipo.Exemplo.Application._Shared.Commands;

public interface ICommand : IRequest
{
}

public interface ICommand<TResponse> : IRequest<TResponse>
{

}

