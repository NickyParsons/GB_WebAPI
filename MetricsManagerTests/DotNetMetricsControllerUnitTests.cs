using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;

namespace MetricsManagerTests
{
    public class DotNetMetricsControllerUnitTests
    {
        private DotNetMetricsController _controller;
        private Mock<ILogger<DotNetMetricsController>> _loggerMock;

        public DotNetMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<DotNetMetricsController>>();
            _controller = new DotNetMetricsController(_loggerMock.Object);
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
