using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using System.Collections.Generic;

namespace MetricsAgentTests
{
    public class NetworkMetricsControllerUnitTests
    {
        private NetworkMetricsController _controller;
        private Mock<ILogger<NetworkMetricsController>> _loggerMock;
        private Mock<INetworkMetricsRepository> _repositoryMock;

        public NetworkMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<NetworkMetricsController>>();
            _repositoryMock = new Mock<INetworkMetricsRepository>();
            _controller = new NetworkMetricsController(_repositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void GetByTimePeriod_ReturnsOk()
        {
            //Arrange
            long fromTime = 1623827400;
            long toTime = 1623828100;
            _repositoryMock.Setup(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>())).Returns(new List<NetworkMetric>());

            //Act
            var result = _controller.GetNetworkMetrics(DateTimeOffset.FromUnixTimeSeconds(fromTime), DateTimeOffset.FromUnixTimeSeconds(toTime));

            // Assert
            _repositoryMock.Verify(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>()), Times.AtMostOnce());
        }
    }
}
