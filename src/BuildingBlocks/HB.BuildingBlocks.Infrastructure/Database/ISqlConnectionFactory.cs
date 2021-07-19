using System.Data;

namespace HB.BuildingBlocks.Infrastructure.Database
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
