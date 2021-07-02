using System;
using MetricsAgent.DAL.Models;
using MetricsAgent.DAL.Interfaces;
using System.Collections.Generic;
using MetricsAgent.DAL.ConnectionMananagers;
using Dapper;
using Core.Interfaces;

namespace MetricsAgent.DAL.Repositories
{
    public class CpuMetricsRepository : ICpuMetricsRepository
    {
        IConnectionManager _connectionManager;
        public CpuMetricsRepository(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }
        public void Create(CpuMetric item)
        {
            using var connection = _connectionManager.GetOpenedConnection();
            {
                connection.Execute("INSERT INTO cpumetrics(value, time) VALUES(@value, @time)", new { value = item.Value, time = item.Time });
            }
        }

        public IList<CpuMetric> GetByTimePeriod(long fromTime, long toTime)
        {
            using var connection = _connectionManager.GetOpenedConnection();
            {
                return (List<CpuMetric>)connection.Query<CpuMetric>("SELECT * FROM cpumetrics WHERE time BETWEEN @fromTime AND @toTime", new { fromTime  = fromTime, toTime = toTime });
            }
        }
    }
}
