namespace Prototipo.Exemplo.Application.DTOs.Ofertas;

public class OfertaDto
{
    public Guid OfertaId { get; set; }
    public OfertaCursoDto OfertaCurso { get; set; } = null!;
    public OfertaInstituicaoDto OfertaInstituicao { get; set; } = null!;
}
