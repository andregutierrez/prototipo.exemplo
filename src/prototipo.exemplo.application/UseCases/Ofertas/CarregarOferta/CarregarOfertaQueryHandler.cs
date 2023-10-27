using Prototipo.Exemplo.Application._Shared.Queries;
using Prototipo.Exemplo.Application.DTOs.Ofertas;
using Prototipo.Exemplo.Domain.Cursos;
using Prototipo.Exemplo.Domain.Instituicoes;
using Prototipo.Exemplo.Domain.Ofertas;

namespace Prototipo.Exemplo.Application.UseCases.Ofertas.CarregarOferta;

public class CarregarOfertaQueryHandler : IQueryHandler<CarregarOfertaQuery, OfertaDto>
{
    public readonly IOfertaRepository _ofertasRepository;
    public readonly ICursoRepository _cursosRepository;
    public readonly IInstituicaoRepository _instituicoesRepository;

    public CarregarOfertaQueryHandler(IOfertaRepository ofertasRepository, ICursoRepository cursosRepository, IInstituicaoRepository instituicoesRepository)
    {
        _ofertasRepository = ofertasRepository;
        _cursosRepository = cursosRepository;
        _instituicoesRepository = instituicoesRepository;
    }

    public async Task<OfertaDto> Handle(CarregarOfertaQuery request, CancellationToken cancellationToken)
    {
        var query =
            from oferta in _ofertasRepository.GetQueryable()
            join curso in _cursosRepository.GetQueryable()
                on oferta.CursoId equals curso.Id
            join instituicoes in _instituicoesRepository.GetQueryable()
                on oferta.InstituicaoId equals instituicoes.Id
            select new OfertaDto()
            {
                OfertaId = oferta.Id,
                OfertaCurso = new OfertaCursoDto()
                {
                    CursoId = curso.Id,
                    Nome = curso.Nome
                },
                OfertaInstituicao = new OfertaInstituicaoDto() 
                { 
                    InstituicaoId = instituicoes.Id,
                    Nome = instituicoes.Nome
                }
            };

        return query
            .Where(o => o.OfertaId.Equals(request.OfertaId))
            .Single();
    }
}
