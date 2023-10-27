using Prototipo.Exemplo.Domain._Shared.Notifications;

namespace Prototipo.Exemplo.Domain._Shared.Validations;

public class ExecutionResult<TReturn>
{
    public bool ValidationSuccess { get; set; }

    public ExecutionResult(TReturn? valueReturn, List<InfoValidation> validations)
    {
        ValueReturn = valueReturn;
        Validations = validations;
        ValidationSuccess = validations.Any() == false;
    }

    private TReturn? ValueReturn { get; set; }
    private List<InfoValidation> Validations { get; set; } = new List<InfoValidation>();

    public ExecutionResult<TReturn> NotificarFalhas(INotificationContext notificationContext)
    {
        if (Validations.Any())
        {
            notificationContext
                .AddNotifications(Validations);
        }
        return this;
    }

    public TReturn? ObterRetorno()
    {
        return ValueReturn;
    }

    public static ExecutionResult<TReturn> Success(TReturn valueReturn)
    {
        return new ExecutionResult<TReturn>(valueReturn, new List<InfoValidation>());
    }

    public static ExecutionResult<TReturn> Fail(List<InfoValidation> validations)
    {
        return new ExecutionResult<TReturn>(default, validations);
    }
}


public class ReturnWithValidation
{
    public bool IsSuccess { get; protected set; }

    public ReturnWithValidation(List<InfoValidation> validations)
    {
        Validations = validations;
        IsSuccess = validations.Any() == false;
    }

    private List<InfoValidation> Validations { get; set; } = new List<InfoValidation>();

    public ReturnWithValidation NotificarFalhas(INotificationContext notificationContext)
    {
        if (Validations.Any())
        {
            notificationContext
                .AddNotifications(Validations);
        }
        return this;
    }

    public static ReturnWithValidation Success()
    {
        return new ReturnWithValidation(new List<InfoValidation>());
    }

    public static ReturnWithValidation Fail(List<InfoValidation> validations)
    {
        return new ReturnWithValidation(validations);
    }
}