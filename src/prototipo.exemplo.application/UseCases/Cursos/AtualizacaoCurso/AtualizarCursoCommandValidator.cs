using FluentValidation;
using Prototipo.Exemplo.Application._Shared.Validations;
using Prototipo.Exemplo.Domain._Shared.Notifications;

namespace Prototipo.Exemplo.Application.UseCases.Cursos.AtualizacaoCurso;

public class AtualizarCursoCommandValidator : ApplicationRequestValidator<AtualizarCursoCommand>
{
    public AtualizarCursoCommandValidator(INotificationContext notificationContext)
        : base(notificationContext)
    {
        RuleFor(x => x.Nome)
            .NotNull()
            .WithMessage("O nome do curso é obrigatório.")
            .Length(3, 255)
            .WithMessage("O nome do curso deve ter entre 3 e 255 caracteres.");
    }
}
