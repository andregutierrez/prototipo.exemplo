using FluentValidation;
using Prototipo.Exemplo.Application._Shared.DTOs;
using Prototipo.Exemplo.Application._Shared.Validations;
using Prototipo.Exemplo.Domain._Shared.Notifications;

namespace Prototipo.Exemplo.Application.UseCases.Cursos.CriacaoCurso;

public class CriarCursoCommandValidator : ApplicationRequestValidator<CriarCursoCommand, EntityIdDto?>
{
    public CriarCursoCommandValidator(INotificationContext notificationContext) : base(notificationContext)
    {
        RuleFor(x => x.Nome)
            .NotNull()
            .WithMessage("O nome do curso é obrigatório.")
            .Length(3, 255)
            .WithMessage("O nome do curso deve ter entre 3 e 255 caracteres.");
    }
}
