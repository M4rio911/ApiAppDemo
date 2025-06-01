using MediatR;

namespace ApiAppDemo.Application.Interfaces.MediatR;

public interface ICommand
{
    public interface ICommand<out TResult> : IRequest<TResult> { }
}
