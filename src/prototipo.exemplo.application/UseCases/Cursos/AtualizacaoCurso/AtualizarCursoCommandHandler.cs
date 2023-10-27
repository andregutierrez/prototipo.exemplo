using Prototipo.Exemplo.Application._Shared.Commands;
using Prototipo.Exemplo.Domain._Shared.Entities;
using Prototipo.Exemplo.Domain._Shared.Notifications;
using Prototipo.Exemplo.Domain.Cursos;

namespace Prototipo.Exemplo.Application.UseCases.Cursos.AtualizacaoCurso;

public class AtualizarCursoCommandHandler : ICommandHandler<AtualizarCursoCommand>
{
    public readonly INotificationContext _notificationContext;
    public readonly IUnitOfWork _unitOfWork;
    public readonly ICursoRepository _cursoRepository;

    public AtualizarCursoCommandHandler(INotificationContext notificationContext, IUnitOfWork unitOfWork, ICursoRepository cursoRepository)
    {
        _notificationContext = notificationContext;
        _unitOfWork = unitOfWork;
        _cursoRepository = cursoRepository;
    }

    public async Task Handle(AtualizarCursoCommand request, CancellationToken cancellationToken)
    {
        var curso = await _cursoRepository
            .GetAsync(request.CursoId);

        curso
            .AtualizarInformacoes(request.Nome);

        _cursoRepository
            .Update(curso);

        await _unitOfWork
            .CommitAsync();
    }
}
