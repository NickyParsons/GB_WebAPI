using System;
using MetricsAgent.DAL.Models;
using MetricsAgent.DAL.Interfaces;
using System.Collections.Generic;
using MetricsAgent.DAL.ConnectionMananagers;
using Dapper;
using Core.Interfaces;

namespace MetricsAgent.DAL.Repositories
{
    public class DotNetMetricsRepository : IDotNetMetricsRepository
    {
        IConnectionManager _connectionManager;
        public DotNetMetricsRepository(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }
        public void Create(DotNetMetric item)
        {
            _connectionManager.CreateOpenedConnection();
            using var connection = _connectionManager.GetOpenedConnection();
            {
                connection.Execute("INSERT INTO dotnetmetrics(value, time) VALUES(@value, @time)", new { value = item.Value, time = item.Time });
            }
        }

        public IList<DotNetMetric> GetByTimePeriod(long fromTime, long toTime)
        {
            _connectionManager.CreateOpenedConnection();
            using var connection = _connectionManager.GetOpenedConnection();
            {
                return (List<DotNetMetric>)connection.Query<DotNetMetric>("SELECT * FROM dotnetmetrics WHERE time BETWEEN @fromTime AND @toTime", new { fromTime = fromTime, toTime = toTime });
            }
        }
    }
}
