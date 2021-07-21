using MediatR;

namespace HB.Core.Application.Configuration
{
    public interface ICommandHandler<Command> : IRequestHandler<Command> where Command : ICommand
    {
    }

    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
    {
    }
}
