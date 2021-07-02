using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using MetricsAgent.Metrics;
using System.Collections.Generic;

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
        public void GetByTimePeriod_ReturnsOk()
        {
            //Arrange
            long fromTime = 1623827400;
            long toTime = 1623828100;
            _repositoryMock.Setup(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>())).Returns(new List<DotNetMetric>());

            //Act
            var result = _controller.GetErrorsCount(DateTimeOffset.FromUnixTimeSeconds(fromTime), DateTimeOffset.FromUnixTimeSeconds(toTime));

            // Assert
            _repositoryMock.Verify(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>()), Times.AtMostOnce());
        }
    }
}
