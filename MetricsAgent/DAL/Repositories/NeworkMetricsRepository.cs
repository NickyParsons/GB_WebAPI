using System;
using MetricsAgent.DAL.Models;
using MetricsAgent.DAL.Interfaces;
using System.Collections.Generic;
using MetricsAgent.DAL.ConnectionMananagers;
using Dapper;
using Core.Interfaces;

namespace MetricsAgent.DAL.Repositories
{
    public class NetworkMetricsRepository : INetworkMetricsRepository
    {
        IConnectionManager _connectionManager;
        public NetworkMetricsRepository(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }
        public void Create(NetworkMetric item)
        {
            _connectionManager.CreateOpenedConnection();
            using var connection = _connectionManager.GetOpenedConnection();
            {
                connection.Execute("INSERT INTO networkmetrics(value, time) VALUES(@value, @time)", new { value = item.Value, time = item.Time });
            }
        }

        public IList<NetworkMetric> GetByTimePeriod(long fromTime, long toTime)
        {
            _connectionManager.CreateOpenedConnection();
            using var connection = _connectionManager.GetOpenedConnection();
            {
                return (List<NetworkMetric>)connection.Query<NetworkMetric>("SELECT * FROM networkmetrics WHERE time BETWEEN @fromTime AND @toTime", new { fromTime = fromTime, toTime = toTime });
            }
        }
    }
}
