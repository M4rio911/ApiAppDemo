using MediatR;

namespace ApiAppDemo.Application.Interfaces.MediatR;

public interface IQueryHandler<in TQuery, TResult>
    : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>{}
