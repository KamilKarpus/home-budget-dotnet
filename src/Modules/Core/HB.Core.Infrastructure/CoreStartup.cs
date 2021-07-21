using Autofac;
using HB.BuildingBlocks.Infrastructure.Database;
using HB.Core.Infrastructure.Configuration.DataAccess;
using HB.Core.Infrastructure.Configuration.Mediation;

namespace HB.Core.Infrastructure
{
    public static class CoreStartup
    {
        public static void RegisterCoreModule(this ContainerBuilder builder, DatabaseSettings settings)
        {
            builder.RegisterModule(new DataAccessModule(settings));
            builder.RegisterModule(new MediationModule());
        }
    }
}
