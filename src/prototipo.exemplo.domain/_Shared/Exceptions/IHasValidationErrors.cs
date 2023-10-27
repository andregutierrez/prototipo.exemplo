namespace Prototipo.Exemplo.Domain._Shared.Exceptions;

public interface IHasValidationErrors
{
    IEnumerable<ValidationException> ValidationInfo { get; }
}
