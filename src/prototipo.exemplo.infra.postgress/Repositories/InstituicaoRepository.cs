using Microsoft.EntityFrameworkCore;
using Prototipo.Exemplo.Domain.Instituicoes;
using Prototipo.Exemplo.Domain.Instituicoes.Entities;
using Prototipo.Exemplo.Infra.Postgress._Shared.Repositories;
using Prototipo.Exemplo.Infra.Postgress.Context;

namespace Prototipo.Exemplo.Infra.Postgress.Repositories;

public class InstituicaoRepository : BaseRepository<Instituicao, InstituicaoId>, IInstituicaoRepository
{
    public InstituicaoRepository(ExemploDbContext dbContext) 
        : base(dbContext) { }
}

