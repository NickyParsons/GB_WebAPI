using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MetricsAgent.Jobs
{
    public class DotNetMetricJob : IJob
    {
        private IDotNetMetricsRepository _repository;
        private PerformanceCounter _dotNetCounter;

        public DotNetMetricJob(IDotNetMetricsRepository repository)
        {
            _repository = repository;
            _dotNetCounter = new PerformanceCounter(".NET CLR Memory", "Gen 0 heap size", "_Global_");
        }

        public Task Execute(IJobExecutionContext context)
        {
            var netGCHeapSize = Convert.ToInt32(_dotNetCounter.NextValue());

            var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            _repository.Create(new DotNetMetric {Time = time, Value = netGCHeapSize });
            return Task.CompletedTask;
        }
    }

}
