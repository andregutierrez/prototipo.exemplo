using Prototipo.Exemplo.Application._Shared.Commands;
using Prototipo.Exemplo.Application._Shared.DTOs;
using Prototipo.Exemplo.Domain._Shared.Entities;
using Prototipo.Exemplo.Domain._Shared.Notifications;
using Prototipo.Exemplo.Domain.Cursos;
using Prototipo.Exemplo.Domain.Cursos.Entities;

namespace Prototipo.Exemplo.Application.UseCases.Cursos.CriacaoCurso;

public class CriarCursoCommandHandler : ICommandHandler<CriarCursoCommand, EntityIdDto?>
{
    public readonly INotificationContext _notificationContext;
    public readonly IUnitOfWork _unitOfWork;
    public readonly ICursoRepository _cursoRepository;

    public CriarCursoCommandHandler(INotificationContext notificationContext, IUnitOfWork unitOfWork, ICursoRepository cursoRepository)
    {
        _notificationContext = notificationContext;
        _unitOfWork = unitOfWork;
        _cursoRepository = cursoRepository;
    }

    public async Task<EntityIdDto?> Handle(CriarCursoCommand request, CancellationToken cancellationToken)
    {
        var curso = Curso
            .Criar(request.Nome ?? "não informado")
            .NotificarFalhas(_notificationContext)
            .ObterRetorno();

        if (curso == null)
            return null;

        await _cursoRepository
            .InsertAsync(curso);

        await _unitOfWork
            .CommitAsync();

        return curso.Id;
    }
}
