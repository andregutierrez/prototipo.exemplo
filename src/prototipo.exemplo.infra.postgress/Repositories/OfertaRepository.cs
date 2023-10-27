using Microsoft.EntityFrameworkCore;
using Prototipo.Exemplo.Domain.Ofertas;
using Prototipo.Exemplo.Domain.Ofertas.Entities;
using Prototipo.Exemplo.Infra.Postgress._Shared.Repositories;
using Prototipo.Exemplo.Infra.Postgress.Context;

namespace Prototipo.Exemplo.Infra.Postgress.Repositories;

public class OfertaRepository : BaseRepository<Oferta, OfertaId>, IOfertaRepository
{
    public OfertaRepository(ExemploDbContext dbContext)
        : base(dbContext) { }
}

