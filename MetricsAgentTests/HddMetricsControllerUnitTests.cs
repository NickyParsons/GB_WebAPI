using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class HddMetricsControllerUnitTests
    {
        private HddMetricsController controller;

        public HddMetricsControllerUnitTests()
        {
            controller = new HddMetricsController();
        }

        [Fact]
        public void GetCpuMetrics_ReturnsOk()
        {
            //Act
            var result = controller.GetHddLeftSpace();

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
