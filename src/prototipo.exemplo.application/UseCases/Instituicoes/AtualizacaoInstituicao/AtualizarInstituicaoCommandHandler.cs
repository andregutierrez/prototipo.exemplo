using Prototipo.Exemplo.Application._Shared.Commands;
using Prototipo.Exemplo.Domain._Shared.Entities;
using Prototipo.Exemplo.Domain._Shared.Notifications;
using Prototipo.Exemplo.Domain.Cursos.Entities;
using Prototipo.Exemplo.Domain.Instituicoes;

namespace Prototipo.Exemplo.Application.UseCases.Instituicoes.AtualizacaoInstituicao;

public class AtualizarInstituicaoCommandHandler : ICommandHandler<AtualizarInstituicaoCommand>
{
    public readonly INotificationContext _notificationContext;
    public readonly IUnitOfWork _unitOfWork;
    public readonly IInstituicaoRepository _instituicaoRepository;

    public AtualizarInstituicaoCommandHandler(INotificationContext notificationContext, IUnitOfWork unitOfWork, IInstituicaoRepository instituicaoRepository)
    {
        _notificationContext = notificationContext;
        _unitOfWork = unitOfWork;
        _instituicaoRepository = instituicaoRepository;
    }

    public async Task Handle(AtualizarInstituicaoCommand request, CancellationToken cancellationToken)
    {
        var instituicao = await _instituicaoRepository
            .GetAsync(request.InstituicaoId);

        instituicao
            .AtualizarInformacoes(request.Nome ?? "não informado");

        _instituicaoRepository
            .Update(instituicao);

        await _unitOfWork
            .CommitAsync();
    }
}
