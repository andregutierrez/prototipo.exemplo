
using Prototipo.Exemplo.Application._Shared.DTOs;
using Prototipo.Exemplo.Application._Shared.Validations;
using Prototipo.Exemplo.Domain._Shared.Notifications;

namespace Prototipo.Exemplo.Application.UseCases.Instituicoes.CriacaoInstituicao;

internal class CriarInstituicaoCommandValidator : ApplicationRequestValidator<CriarInstituicaoCommand, EntityIdDto>
{
    public CriarInstituicaoCommandValidator(INotificationContext notificationContext)
        : base(notificationContext)
    {
        // TODO: implementar validações com o FluentValidation
    }
}
