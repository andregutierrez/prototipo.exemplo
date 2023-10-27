using Microsoft.Extensions.DependencyInjection;

namespace Prototipo.Exemplo.Domain._Shared.Validations;

public class ValidatorProvider
{
    private readonly IServiceProvider _serviceProvider;
    private static ValidatorProvider _instance;

    private ValidatorProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public static ValidatorProvider Instance
    {
        get
        {
            if (_instance == null)
            {
                throw new InvalidOperationException("ValidatorProvider não foi inicializado.");
            }
            return _instance;
        }
    }

    public static void Initialize(IServiceProvider serviceProvider)
    {
        if (_instance != null)
        {
            throw new InvalidOperationException("ValidatorProvider já foi inicializado.");
        }
        _instance = new ValidatorProvider(serviceProvider);
    }

    public T GetValidator<T>() where T : DomainValidator
    {
        return _serviceProvider
            .CreateScope().ServiceProvider
            .GetRequiredService<T>();
    }
}



