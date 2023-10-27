using Prototipo.Exemplo.Application._Shared.Validations;
using Prototipo.Exemplo.Domain._Shared.Notifications;

namespace Prototipo.Exemplo.Application.UseCases.Instituicoes.AtualizacaoInstituicao;

public class AtualizarInstituicaoCommandValidator : ApplicationRequestValidator<AtualizarInstituicaoCommand>
{
    public AtualizarInstituicaoCommandValidator(INotificationContext notificationContext)
        : base(notificationContext)
    {
        // TODO: implementar validações com o FluentValidation
    }
}
