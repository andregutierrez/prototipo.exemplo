using Prototipo.Exemplo.Application._Shared.Commands;
using Prototipo.Exemplo.Application._Shared.DTOs;
using Prototipo.Exemplo.Domain._Shared.Entities;
using Prototipo.Exemplo.Domain._Shared.Notifications;
using Prototipo.Exemplo.Domain.Instituicoes;
using Prototipo.Exemplo.Domain.Instituicoes.Entities;

namespace Prototipo.Exemplo.Application.UseCases.Instituicoes.CriacaoInstituicao;

public class CriarInstituicaoCommandHandler : ICommandHandler<CriarInstituicaoCommand, EntityIdDto?>
{
    public readonly INotificationContext _notificationContext;
    public readonly IUnitOfWork _unitOfWork;
    public readonly IInstituicaoRepository _instituicaoRepository;

    public CriarInstituicaoCommandHandler(INotificationContext notificationContext, IUnitOfWork unitOfWork, IInstituicaoRepository instituicaoRepository)
    {
        _notificationContext = notificationContext;
        _unitOfWork = unitOfWork;
        _instituicaoRepository = instituicaoRepository;
    }

    public async Task<EntityIdDto?> Handle(CriarInstituicaoCommand request, CancellationToken cancellationToken)
    {
        var instituicao = Instituicao
            .Criar(request.Nome ?? "não informado")
            .NotificarFalhas(_notificationContext)
            .ObterRetorno();

        if (instituicao == null)
            return null;

        await _instituicaoRepository
            .InsertAsync(instituicao);

        await _unitOfWork
            .CommitAsync();

        return instituicao.Id;
    }
}
