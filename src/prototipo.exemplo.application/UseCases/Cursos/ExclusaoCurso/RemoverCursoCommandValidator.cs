using Prototipo.Exemplo.Application._Shared.Validations;
using Prototipo.Exemplo.Domain._Shared.Notifications;

namespace Prototipo.Exemplo.Application.UseCases.Cursos.ExclusaoCurso;

public class RemoverCursoCommandValidator : ApplicationRequestValidator<RemoverCursoCommand>
{
    public RemoverCursoCommandValidator(INotificationContext notificationContext)
        : base(notificationContext)
    {
        // TODO: implementar validações com o FluentValidation
    }
}
