using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;

namespace MetricsAgentTests
{
    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController _controller;
        private Mock<ILogger<RamMetricsController>> _loggerMock;
        private Mock<IRamMetricsRepository> _repositoryMock;

        public RamMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<RamMetricsController>>();
            _repositoryMock = new Mock<IRamMetricsRepository>();
            _controller = new RamMetricsController(_repositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void GetRamMetrics_ReturnsOk()
        {
            //Arrange
            var fromTime = DateTimeOffset.Parse("10:00");
            var toTime = DateTimeOffset.Parse("10:30");

            //Act
            var result = _controller.GetRamAvaibleSize(fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
