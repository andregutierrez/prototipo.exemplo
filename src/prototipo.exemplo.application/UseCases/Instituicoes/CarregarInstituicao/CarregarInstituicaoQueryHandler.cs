using Microsoft.EntityFrameworkCore;
using Prototipo.Exemplo.Application._Shared.Queries;
using Prototipo.Exemplo.Application.DTOs.Instituicoes;
using Prototipo.Exemplo.Domain.Instituicoes;

namespace Prototipo.Exemplo.Application.UseCases.Instituicoes.CarregarInstituicao;

public class CarregarInstituicaoQueryHandler : IQueryHandler<CarregarInstituicaoQuery, InstituicaoDto>
{
    public readonly IInstituicaoRepository _instituicaoRepository;

    public CarregarInstituicaoQueryHandler(IInstituicaoRepository instituicaoRepository)
    {
        _instituicaoRepository = instituicaoRepository;
    }

    public async Task<InstituicaoDto> Handle(CarregarInstituicaoQuery request, CancellationToken cancellationToken)
    {
        var query = _instituicaoRepository
            .GetQueryable()
            .Select(o => new InstituicaoDto()
            {
                InstituicaoId = o.Id,
                Nome = o.Nome
            });

        return await query
            .SingleAsync();
    }
}
