using Microsoft.EntityFrameworkCore;
using Prototipo.Exemplo.Application._Shared.Queries;
using Prototipo.Exemplo.Application.DTOs.Ofertas;
using Prototipo.Exemplo.Domain.Cursos;
using Prototipo.Exemplo.Domain.Instituicoes;
using Prototipo.Exemplo.Domain.Ofertas;

namespace Prototipo.Exemplo.Application.UseCases.Ofertas.PesquisaOfertas;

public class PesquisarOfertaQueryHandler : IQueryHandler<PesquisarOfertaQuery, IEnumerable<OfertaDto>>
{
    public readonly IOfertaRepository _ofertasRepository;
    public readonly ICursoRepository _cursosRepository;
    public readonly IInstituicaoRepository _instituicoesRepository;

    public PesquisarOfertaQueryHandler(IOfertaRepository ofertasRepository, ICursoRepository cursosRepository, IInstituicaoRepository instituicoesRepository)
    {
        _ofertasRepository = ofertasRepository;
        _cursosRepository = cursosRepository;
        _instituicoesRepository = instituicoesRepository;
    }

    public async Task<IEnumerable<OfertaDto>> Handle(PesquisarOfertaQuery request, CancellationToken cancellationToken)
    {
        var query =
            from oferta in _ofertasRepository.GetQueryable()
            join curso in _cursosRepository.GetQueryable()
                on oferta.CursoId.Id equals curso.Id.Id
            join instituicoes in _instituicoesRepository.GetQueryable()
                on oferta.InstituicaoId.Id equals instituicoes.Id.Id
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

        return await query
            .ToListAsync();
    }
}

