// namespace Anima.Servico.Core.Application.Commands;

// public class CommandResult<TValue> : ICommandResult<TValue>
// {
//     private bool _isSuccess;

//     private TValue? _value;

//     public CommandResult(bool isSuccess, TValue? value)
//     {
//         _isSuccess = isSuccess;
//         _value = value;
//     }

//     public bool IsSuccess => _isSuccess;

//     public TValue? Value => _value;

//     public static ICommandResult<TValue> Success(TValue? Value)
//     {
//         return new CommandResult<TValue>(true, Value);
//     }

//     public static ICommandResult<TValue> Fail()
//     {
//         return new CommandResult<TValue>(false, default);
//     }
// }


// public class CommandResult : ICommandResult
// {
//     private bool _isSuccess;

//     public CommandResult(bool isSuccess)
//     {
//         _isSuccess = isSuccess;
//     }

//     public bool IsSuccess => _isSuccess;

//     public static ICommandResult Success()
//     {
//         return new CommandResult(true);
//     }

//     public static ICommandResult Fail()
//     {
//         return new CommandResult(false);
//     }
// }