using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Metrics;

namespace MetricsAgent.DAL
{
    public interface INetworkMetricsRepository : IRepository<NetworkMetric>
    {
    }
}
