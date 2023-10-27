using Prototipo.Exemplo.Application._Shared.Commands;
using Prototipo.Exemplo.Application._Shared.DTOs;
using Prototipo.Exemplo.Domain._Shared.Entities;
using Prototipo.Exemplo.Domain._Shared.Notifications;
using Prototipo.Exemplo.Domain.Ofertas;
using Prototipo.Exemplo.Domain.Ofertas.Entities;

namespace Prototipo.Exemplo.Application.UseCases.Ofertas.CriarOferta;

public class CriarOfertaCommandHandler : ICommandHandler<CriarOfertaCommand, EntityIdDto?>
{
    public readonly INotificationContext _notificationContext;
    public readonly IUnitOfWork _unitOfWork;
    public readonly IOfertaRepository _ofertaRepository;

    public CriarOfertaCommandHandler(INotificationContext notificationContext, IUnitOfWork unitOfWork, IOfertaRepository ofertaRepository)
    {
        _notificationContext = notificationContext;
        _unitOfWork = unitOfWork;
        _ofertaRepository = ofertaRepository;
    }

    public async Task<EntityIdDto?> Handle(CriarOfertaCommand request, CancellationToken cancellationToken)
    {
        var oferta = Oferta
            .Criar(request.CursoId, request.InstituicaoId)
            .NotificarFalhas(_notificationContext)
            .ObterRetorno();

        if (oferta == null)
            return null;

        await _ofertaRepository
            .InsertAsync(oferta);

        await _unitOfWork
            .CommitAsync();

        return oferta.Id;
    }
}
