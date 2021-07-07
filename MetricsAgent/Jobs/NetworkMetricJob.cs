using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class NetworkMetricJob : IJob
    {
        private INetworkMetricsRepository _repository;
        private PerformanceCounter _networkCounter;

        public NetworkMetricJob(INetworkMetricsRepository repository)
        {
            _repository = repository;
            _networkCounter = new PerformanceCounter("Network Adapter", "Bytes Total/sec", "Realtek PCIe GBE Family Controller");
        }

        public Task Execute(IJobExecutionContext context)
        {
            var bytesInSec = Convert.ToInt32(_networkCounter.NextValue());

            var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            _repository.Create(new NetworkMetric {Time = time, Value = bytesInSec });
            return Task.CompletedTask;
        }
    }

}
