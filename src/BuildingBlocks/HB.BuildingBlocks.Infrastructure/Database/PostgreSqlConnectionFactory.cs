using Npgsql;
using System;
using System.Data;

namespace HB.BuildingBlocks.Infrastructure.Database
{
    public class PostgreSqlConnectionFactory : IDisposable, ISqlConnectionFactory
    {
        private readonly string _connectionString;
        private IDbConnection _connection;
        public PostgreSqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IDbConnection GetConnection()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new NpgsqlConnection(_connectionString);
                return _connection;
            }
            return _connection;
        }

        public void Dispose()
        {
            if (this._connection != null && this._connection.State == ConnectionState.Open)
            {
                this._connection.Dispose();
            }
        }
    }
}
