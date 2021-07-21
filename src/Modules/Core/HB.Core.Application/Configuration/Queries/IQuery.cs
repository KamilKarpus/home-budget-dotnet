using MediatR;

namespace HB.Core.Application.Configuration.Queries
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }
}
