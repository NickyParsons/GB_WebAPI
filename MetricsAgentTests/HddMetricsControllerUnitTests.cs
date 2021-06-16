using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;

namespace MetricsAgentTests
{
    public class HddMetricsControllerUnitTests
    {
        private HddMetricsController _controller;
        private Mock<ILogger<HddMetricsController>> _loggerMock;
        private Mock<IHddMetricsRepository> _repositoryMock;

        public HddMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<HddMetricsController>>();
            _repositoryMock = new Mock<IHddMetricsRepository>();
            _controller = new HddMetricsController(_repositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void GetHddMetrics_ReturnsOk()
        {
            //Arrange
            var fromTime = DateTimeOffset.Parse("10:00");
            var toTime = DateTimeOffset.Parse("10:30");

            //Act
            var result = _controller.GetHddLeftSpace(fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
