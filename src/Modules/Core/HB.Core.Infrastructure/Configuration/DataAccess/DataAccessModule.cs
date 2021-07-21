using Autofac;
using HB.BuildingBlocks.Infrastructure.Database;

namespace HB.Core.Infrastructure.Configuration.DataAccess
{
    public class DataAccessModule : Autofac.Module
    {
        private readonly DatabaseSettings _settings;

        public DataAccessModule(DatabaseSettings settings)
        {
            _settings = settings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PostgreSqlConnectionFactory>()
                .As<ISqlConnectionFactory>()
                .WithParameter("connectionString", _settings.ConnectionString);

            base.Load(builder);
        }
    }
}
