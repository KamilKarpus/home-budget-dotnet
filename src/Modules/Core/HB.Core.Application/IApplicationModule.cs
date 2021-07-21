using HB.Core.Application.Configuration;
using HB.Core.Application.Configuration.Queries;
using System;
using System.Threading.Tasks;

namespace HB.Core.Application
{
    public interface IApplicationModule
    {
        public Task ExecuteCommand(ICommand command);
        public Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query) where TResult : class;
        public Task<TResult> ExecuteCommand<TResult>(ICommand<TResult> command) where TResult : class;
    }
}
