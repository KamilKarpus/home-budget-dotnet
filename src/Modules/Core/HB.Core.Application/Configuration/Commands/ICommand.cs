using MediatR;

namespace HB.Core.Application.Configuration
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<TResponse> : IRequest<TResponse>
    {

    }
}
