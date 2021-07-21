using MediatR;

namespace HB.Core.Application.Configuration.Queries
{
    public interface IQueryHandler<in TQuery,TResponse> : IRequestHandler<IQuery<TResponse>, TResponse> where TQuery : IQuery<TResponse>
    {
    }
}
