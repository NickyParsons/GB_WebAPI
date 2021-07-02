using MetricsManager;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;

namespace MetricsManagerTests
{
    public class AgentsControllerUnitTests
    {
        private AgentsController _controller;
        private Mock<ILogger<AgentsController>> _loggerMock;

        public AgentsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<AgentsController>>();
            _controller = new AgentsController(_loggerMock.Object);
        }

        [Fact]
        public void GetAgentsList_ReturnsOk()
        {
            //Arrange

            //Act
            var result = _controller.GetAgentsList();

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void RegisterAgent_ReturnsOk()
        {
            //Arrange
            AgentInfo agentInfo = new AgentInfo();

            //Act
            var result = _controller.RegisterAgent(agentInfo);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void EnableAgentById_ReturnsOk()
        {
            //Arrange
            var agentId = 1;

            //Act
            var result = _controller.EnableAgentById(agentId);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void DisableAgentById_ReturnsOk()
        {
            //Arrange
            var agentId = 1;

            //Act
            var result = _controller.DisableAgentById(agentId);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
