using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace MiddlewareDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MiddlewareController(ILogger<MiddlewareController> _logger) : ControllerBase
    {
        private readonly Random _random = new();

        [HttpGet("rate-limiting")]
        [EnableRateLimiting(policyName:"fixed")]
        public ActionResult RateLimitingDemo()
        {
            return Ok($"Hello {DateTime.Now.Ticks.ToString()}");
        }
        
        [HttpGet("request-timeout")]
        [RequestTimeout(5000)]
        public async Task<ActionResult> RequestTimeoutDemo()
        {
            var delay = _random.Next(1, 10);
            _logger.LogInformation($"Delay for {delay} seconds");
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(delay), Request.HttpContext.RequestAborted);
            }
            catch
            {
                _logger.LogWarning("The request timed out");
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "The request time out");
            }
            return Ok($"Hello! The task is completed in {delay} seconds");
        }

        [HttpGet("request-timeout-short")]
        [RequestTimeout("ShortTimeoutPolicy")]
        public async Task<ActionResult> RequestTimeoutShortDemo()
        {
            var delay = _random.Next(1, 4);
            _logger.LogInformation($"Delay for {delay} seconds");
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(delay), Request.HttpContext.RequestAborted);
            }
            catch
            {
                _logger.LogWarning("The request timed out");
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "The request time out");
            }
            return Ok($"Hello! The task is completed in {delay} seconds");
        }
    }
}