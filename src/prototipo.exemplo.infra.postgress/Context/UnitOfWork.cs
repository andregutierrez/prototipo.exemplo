using Microsoft.EntityFrameworkCore;
using Prototipo.Exemplo.Domain._Shared.Entities;

namespace Prototipo.Exemplo.Infra.Postgress.Context;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _dbContext;

    public UnitOfWork(ExemploDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        => await _dbContext.SaveChangesAsync(cancellationToken);
}
