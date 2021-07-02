using System;
using MetricsAgent.DAL.Models;
using MetricsAgent.DAL.Interfaces;
using System.Collections.Generic;
using MetricsAgent.DAL.ConnectionMananagers;
using Dapper;
using Core.Interfaces;

namespace MetricsAgent.DAL.Repositories
{
    public class HddMetricsRepository : IHddMetricsRepository
    {
        IConnectionManager _connectionManager;
        public HddMetricsRepository(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }
        public void Create(HddMetric item)
        {
            using var connection = _connectionManager.GetOpenedConnection();
            {
                connection.Execute("INSERT INTO hddmetrics(value, time) VALUES(@value, @time)", new { value = item.Value, time = item.Time });
            }
        }

        public IList<HddMetric> GetByTimePeriod(long fromTime, long toTime)
        {
            using var connection = _connectionManager.GetOpenedConnection();
            {
                return (List<HddMetric>)connection.Query<HddMetric>("SELECT * FROM hddmetrics WHERE time BETWEEN @fromTime AND @toTime", new { fromTime = fromTime, toTime = toTime });
            }
        }
    }
}
