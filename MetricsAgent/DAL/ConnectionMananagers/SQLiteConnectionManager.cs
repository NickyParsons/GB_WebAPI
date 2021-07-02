using System.Data.SQLite;
using System.Data.Common;
using Core.Interfaces;

namespace MetricsAgent.DAL.ConnectionMananagers
{
    public class SQLiteConnectionManager
    {
        private readonly string _connectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        private readonly SQLiteConnection _connection;
        public SQLiteConnectionManager()
        {
            _connection = new SQLiteConnection(_connectionString);
            _connection.Open();
        }
        public SQLiteConnection GetOpenedConnection()
        {
            return _connection;
        }
    }
}
