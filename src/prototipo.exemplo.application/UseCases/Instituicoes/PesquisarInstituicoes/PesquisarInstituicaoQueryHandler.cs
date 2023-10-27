using Microsoft.EntityFrameworkCore;
using Prototipo.Exemplo.Application._Shared.Queries;
using Prototipo.Exemplo.Application.DTOs.Instituicoes;
using Prototipo.Exemplo.Domain.Instituicoes;

namespace Prototipo.Exemplo.Application.UseCases.Instituicoes.PesquisarInstituicoes;

public class PesquisarInstituicaoQueryHandler : IQueryHandler<PesquisarInstituicaoQuery, IEnumerable<InstituicaoDto>>
{
    public readonly IInstituicaoRepository _instituicaoRepository;

    public PesquisarInstituicaoQueryHandler(IInstituicaoRepository instituicaoRepository)
    {
        _instituicaoRepository = instituicaoRepository;
    }

    public async Task<IEnumerable<InstituicaoDto>> Handle(PesquisarInstituicaoQuery request, CancellationToken cancellationToken)
    {
        var query = _instituicaoRepository
            .GetQueryable()
            .Select(o => new InstituicaoDto() { 
                InstituicaoId = o.Id,
                Nome = o.Nome
            });

        return await query
            .ToListAsync();
    }
}

