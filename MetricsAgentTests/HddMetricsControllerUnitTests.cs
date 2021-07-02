using MetricsAgent.Controllers;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using System.Collections.Generic;
using AutoMapper;

namespace MetricsAgentTests
{
    public class HddMetricsControllerUnitTests
    {
        private HddMetricsController _controller;
        private Mock<ILogger<HddMetricsController>> _loggerMock;
        private Mock<IHddMetricsRepository> _repositoryMock;
        private Mock<IMapper> _mapper;

        public HddMetricsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<HddMetricsController>>();
            _repositoryMock = new Mock<IHddMetricsRepository>();
            _mapper = new Mock<IMapper>();
            _controller = new HddMetricsController(_repositoryMock.Object, _loggerMock.Object, _mapper.Object);
        }

        [Fact]
        public void GetByTimePeriod_ReturnsOk()
        {
            //Arrange
            long fromTime = 1623827400;
            long toTime = 1623828100;
            _repositoryMock.Setup(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>())).Returns(new List<HddMetric>());

            //Act
            var result = _controller.GetHddLeftSpace(DateTimeOffset.FromUnixTimeSeconds(fromTime), DateTimeOffset.FromUnixTimeSeconds(toTime));

            // Assert
            _repositoryMock.Verify(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>()), Times.AtMostOnce());
        }
    }
}
