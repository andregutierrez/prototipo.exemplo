using Prototipo.Exemplo.Application._Shared.Commands;
using Prototipo.Exemplo.Domain._Shared.Entities;
using Prototipo.Exemplo.Domain._Shared.Notifications;
using Prototipo.Exemplo.Domain.Instituicoes;

namespace Prototipo.Exemplo.Application.UseCases.Instituicoes.ExclusaoInstituicao;

public class RemoverInstituicaoCommandHandler : ICommandHandler<RemoverInstituicaoCommand>
{
    public readonly INotificationContext _notificationContext;
    public readonly IUnitOfWork _unitOfWork;
    public readonly IInstituicaoRepository _instituicaoRepository;

    public RemoverInstituicaoCommandHandler(INotificationContext notificationContext, IUnitOfWork unitOfWork, IInstituicaoRepository instituicaoRepository)
    {
        _notificationContext = notificationContext;
        _unitOfWork = unitOfWork;
        _instituicaoRepository = instituicaoRepository;
    }

    public async Task Handle(RemoverInstituicaoCommand request, CancellationToken cancellationToken)
    {
        var instituicao = await _instituicaoRepository
            .GetAsync(request.InstituicaoId);

        _instituicaoRepository
            .Delete(instituicao);

        await _unitOfWork
            .CommitAsync();
    }
}
