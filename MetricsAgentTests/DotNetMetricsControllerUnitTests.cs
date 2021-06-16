using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;

namespace MetricsAgentTests
{
    public class DotNetMetricsControllerUnitTests
    {
        private DotNetMetricsController _controller;
        private Mock<ILogger<DotNetMetricsController>> _loggerMock;
        private Mock<IDotNetMetricsRepository> _repositoryMock;

        public DotNetMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<DotNetMetricsController>>();
            _repositoryMock = new Mock<IDotNetMetricsRepository>();
            _controller = new DotNetMetricsController(_repositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void GetDotNetMetrics_ReturnsOk()
        {
            //Arrange
            var fromTime = DateTimeOffset.Parse("10:00");
            var toTime = DateTimeOffset.Parse("10:30");

            //Act
            var result = _controller.GetErrorsCount(fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
