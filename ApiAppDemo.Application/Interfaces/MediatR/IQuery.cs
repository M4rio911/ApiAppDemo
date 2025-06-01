using MediatR;

namespace ApiAppDemo.Application.Interfaces.MediatR;

public interface IQuery<out T> : IRequest<T> { }
