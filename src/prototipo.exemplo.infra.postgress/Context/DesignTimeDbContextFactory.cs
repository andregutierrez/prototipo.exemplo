using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace Prototipo.Exemplo.Infra.Postgress.Context;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ExemploDbContext>
{
    public ExemploDbContext CreateDbContext(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<ExemploDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryExemplo");
            })
            .BuildServiceProvider();

        return serviceProvider.GetRequiredService<ExemploDbContext>();
    }
}
