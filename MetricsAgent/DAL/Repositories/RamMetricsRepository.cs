using System;
using MetricsAgent.DAL.Models;
using MetricsAgent.DAL.Interfaces;
using System.Collections.Generic;
using MetricsAgent.DAL.ConnectionMananagers;
using Dapper;
using Core.Interfaces;

namespace MetricsAgent.DAL.Repositories
{
    public class RamMetricsRepository : IRamMetricsRepository
    {
        IConnectionManager _connectionManager;
        public RamMetricsRepository(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }
        public void Create(RamMetric item)
        {
            _connectionManager.CreateOpenedConnection();
            using var connection = _connectionManager.GetOpenedConnection();
            {
                connection.Execute("INSERT INTO rammetrics(value, time) VALUES(@value, @time)", new { value = item.Value, time = item.Time });
            }
        }

        public IList<RamMetric> GetByTimePeriod(long fromTime, long toTime)
        {
            _connectionManager.CreateOpenedConnection();
            using var connection = _connectionManager.GetOpenedConnection();
            {
                return (List<RamMetric>)connection.Query<RamMetric>("SELECT * FROM rammetrics WHERE time BETWEEN @fromTime AND @toTime", new { fromTime = fromTime, toTime = toTime });
            }
        }
    }
}
