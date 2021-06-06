using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController controller;

        public RamMetricsControllerUnitTests()
        {
            controller = new RamMetricsController();
        }

        [Fact]
        public void GetCpuMetrics_ReturnsOk()
        {
            //Act
            var result = controller.GetRamAvaibleSize();

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
