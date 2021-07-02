using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;

namespace MetricsManagerTests
{
    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController _controller;
        private Mock<ILogger<RamMetricsController>> _loggerMock;

        public RamMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<RamMetricsController>>();
            _controller = new RamMetricsController(_loggerMock.Object);
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange
            var agentId = 1;
            var fromTime = DateTimeOffset.Parse("10:00");
            var toTime = DateTimeOffset.Parse("10:30");

            //Act
            var result = _controller.GetMetricsFromAgent(agentId, fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void GetMetricsFromAllCluster_ReturnsOk()
        {
            //Arrange
            var fromTime = DateTimeOffset.Parse("10:00");
            var toTime = DateTimeOffset.Parse("10:30");

            //Act
            var result = _controller.GetMetricsFromAllCluster(fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
