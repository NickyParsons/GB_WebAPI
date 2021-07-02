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
        public void GetByTimePeriod_ReturnsOk()
        {
            //Arrange
            long fromTime = 1623827400;
            long toTime = 1623828100;
            _repositoryMock.Setup(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>())).Returns(new List<RamMetric>());

            //Act
            var result = _controller.GetRamAvaibleSize(DateTimeOffset.FromUnixTimeSeconds(fromTime), DateTimeOffset.FromUnixTimeSeconds(toTime));

            // Assert
            _repositoryMock.Verify(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>()), Times.AtMostOnce());
        }
    }
}
