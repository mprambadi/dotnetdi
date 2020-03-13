using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace webApiDi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

            private readonly ILogger<WeatherForecastController> _logger;
            private readonly IOperationTransient _transientOperation;
            private readonly IOperationScoped _scopedOperation;
            private readonly IOperationSingleton _singletonOperation;
        private readonly TestService _testService;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,         
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation,
            TestService testService
        )
        {
            _logger = logger;
            _transientOperation = transientOperation;
            _scopedOperation = scopedOperation;
            _singletonOperation = singletonOperation;
            _testService = testService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var rng = new Random();

            return Ok(new {
                transientOperation = _transientOperation.OperationId,
                testServicetransientOperation = _testService._transientOperation.OperationId,
                scopedOperation = _scopedOperation.OperationId,
                testServicescopedOperation = _testService._scopedOperation.OperationId,
                singletonOperation = _singletonOperation.OperationId,
                testServicesingletonOperation = _testService._singletonOperation.OperationId,
            });
            
        }
    }
}
