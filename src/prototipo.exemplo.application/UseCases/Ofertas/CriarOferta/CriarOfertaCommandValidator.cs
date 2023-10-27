using Prototipo.Exemplo.Application._Shared.DTOs;
using Prototipo.Exemplo.Application._Shared.Validations;
using Prototipo.Exemplo.Domain._Shared.Notifications;

namespace Prototipo.Exemplo.Application.UseCases.Ofertas.CriarOferta;

public class CriarOfertaCommandValidator : ApplicationRequestValidator<CriarOfertaCommand, EntityIdDto?>
{
    public CriarOfertaCommandValidator(INotificationContext notificationContext)
        : base(notificationContext)
    {
        // TODO: implementar validações com o FluentValidation
    }
}
