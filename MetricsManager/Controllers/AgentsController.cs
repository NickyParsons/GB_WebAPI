using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly ILogger<AgentsController> _logger;
        
        public AgentsController(ILogger<AgentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("list")]
        public IActionResult GetAgentsList ()
        {
            return Ok();
        }
        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            _logger.LogInformation($"Registred new agent (agentID: {agentInfo.AgentId}, agentAddress: {agentInfo.AgentAddress}");
            return Ok();
        }

        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            _logger.LogInformation($"Agent enabled (agentID: {agentId}");
            return Ok();
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            _logger.LogInformation($"Agent disabled (agentID: {agentId}");
            return Ok();
        }
    }
}
