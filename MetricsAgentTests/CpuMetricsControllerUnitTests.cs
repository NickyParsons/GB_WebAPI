using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;

namespace MetricsAgentTests
{
    public class CpuMetricsControllerUnitTests
    {
        private CpuMetricsController _controller;
        private Mock<ILogger<CpuMetricsController>> _loggerMock;
        private Mock<ICpuMetricsRepository> _repositoryMock;

        public CpuMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<CpuMetricsController>>();
            _repositoryMock = new Mock<ICpuMetricsRepository>();
            _controller = new CpuMetricsController(_repositoryMock.Object ,_loggerMock.Object);
        }

        [Fact]
        public void GetCpuMetrics_ReturnsOk()
        {
            //Arrange
            var fromTime = DateTimeOffset.Parse("10:00");
            var toTime = DateTimeOffset.Parse("10:30");

            //Act
            var result = _controller.GetByTimePeriod(fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
