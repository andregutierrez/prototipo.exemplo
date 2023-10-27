using Prototipo.Exemplo.Application._Shared.Commands;
using Prototipo.Exemplo.Application._Shared.DTOs;

namespace Prototipo.Exemplo.Application.UseCases.Ofertas.CriarOferta;

public class CriarOfertaCommand : ICommand<EntityIdDto?>
{
    public Guid CursoId { get; set; }
    public Guid InstituicaoId { get; set; }
}
