using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace NLogWithASPNETCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet("InitiateRequest")]
        public IActionResult InitiateRequest()
        {
            try
            {
                _logger.LogInformation("This is a message from LogInformation method");
                _logger.LogError("This is a message from LogError method");

                return Ok("I am okay");
            }
            catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, ex.Message, null);
                return BadRequest();
            }
        }
    }
}