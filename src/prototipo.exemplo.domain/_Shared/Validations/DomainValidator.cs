namespace Prototipo.Exemplo.Domain._Shared.Validations;

public abstract class DomainValidator
{
    private List<InfoValidation> _validations = new List<InfoValidation>();

    public List<InfoValidation> Validations { get => _validations; protected set => _validations = value; }
}