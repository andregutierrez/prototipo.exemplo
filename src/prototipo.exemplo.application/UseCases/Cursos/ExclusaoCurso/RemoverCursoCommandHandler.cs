using Prototipo.Exemplo.Application._Shared.Commands;
using Prototipo.Exemplo.Domain._Shared.Entities;
using Prototipo.Exemplo.Domain._Shared.Notifications;
using Prototipo.Exemplo.Domain.Cursos;

namespace Prototipo.Exemplo.Application.UseCases.Cursos.ExclusaoCurso;

public class RemoverCursoCommandHandler : ICommandHandler<RemoverCursoCommand>
{
    public readonly INotificationContext _notificationContext;
    public readonly IUnitOfWork _unitOfWork;
    public readonly ICursoRepository _cursoRepository;

    public RemoverCursoCommandHandler(INotificationContext notificationContext, IUnitOfWork unitOfWork, ICursoRepository cursoRepository)
    {
        _notificationContext = notificationContext;
        _unitOfWork = unitOfWork;
        _cursoRepository = cursoRepository;
    }

    public async Task Handle(RemoverCursoCommand request, CancellationToken cancellationToken)
    {
        var curso = await _cursoRepository
            .GetAsync(request.CursoId);

        _cursoRepository
            .Delete(curso);

        await _unitOfWork
            .CommitAsync();
    }
}
