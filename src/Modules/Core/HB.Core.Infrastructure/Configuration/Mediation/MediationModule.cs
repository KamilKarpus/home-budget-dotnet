using Autofac;
using HB.BuildingBlocks.Infrastructure.Configuration;
using HB.BuildingBlocks.Infrastructure.Configuration.Mediation;
using HB.Core.Application.Configuration;
using MediatR;
using System.Reflection;

namespace HB.Core.Infrastructure.Configuration.Mediation
{
    public class MediationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();

            builder.RegisterSource(new ScopedContravariantRegistrationSource(
                typeof(ICommandHandler<,>), typeof(IRequestHandler<,>), typeof(ICommandHandler<>), typeof(INotificationHandler<>)));

            var mediatorOpenTypes = new[]
            {
                 typeof(ICommandHandler<>),
                 typeof(ICommandHandler<,>),
                 typeof(IRequestHandler<,>),
                 typeof(INotificationHandler<>)
            };

            foreach (var mediatorOpenType in mediatorOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(ThisAssembly, Assemblies.Application)
                    .AsClosedTypesOf(mediatorOpenType)
                    .AsImplementedInterfaces()
                    .FindConstructorsWith(new AllConstructorFinder());
            }

            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            }).InstancePerLifetimeScope();

        }
    }
}
