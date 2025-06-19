using System;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class LogController : BaseApiController
{
    private readonly ILogger<LogController> _logger;

    public LogController(ILogger<LogController> logger)
    {
        _logger = logger;

    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Consulta recibida en {Time}", DateTime.UtcNow);
        return Ok();
    }
}
