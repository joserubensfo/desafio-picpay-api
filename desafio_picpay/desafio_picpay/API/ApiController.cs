using Microsoft.AspNetCore.Mvc;

namespace desafio_picpay.API
{
    [ApiController]
    [Route("api")]
    public class ApiController
    {
        private readonly ILogger<ApiController> _logger;
        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }
    }
}
