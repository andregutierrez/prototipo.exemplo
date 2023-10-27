using Prototipo.Exemplo.Application._Shared.Validations;
using Prototipo.Exemplo.Domain._Shared.Notifications;

namespace Prototipo.Exemplo.Application.UseCases.Instituicoes.ExclusaoInstituicao;

public class RemoverInstituicaoCommandValidator : ApplicationRequestValidator<RemoverInstituicaoCommand>
{
    public RemoverInstituicaoCommandValidator(INotificationContext notificationContext)
        : base(notificationContext)
    {
        // TODO: implementar validações com o FluentValidation
    }
}
