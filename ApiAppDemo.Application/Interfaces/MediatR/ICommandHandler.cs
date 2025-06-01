using MediatR;
using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Interfaces.MediatR;

public interface ICommandHandler<in TCommand, TResult>
    : IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
}
