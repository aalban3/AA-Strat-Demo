using AADemo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AADemo.API.Controllers;

[ApiController]
[Route("/api/credit-data")]
public class CreditDataController : ControllerBase
{

    private readonly ILogger<CreditDataController> _logger;
    private readonly ICreditDataService _creditDataService;

    public CreditDataController(ILogger<CreditDataController> logger, ICreditDataService creditDataService)
    {
        _logger = logger;
        _creditDataService = creditDataService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] long? applicationId, [FromQuery] string? source, [FromQuery] string? bureau)
    {
        try
        {
            if (
                applicationId == null ||
                source == null ||
                bureau == null )
            {
                return BadRequest("Missing required fields");
            }

            var result = await _creditDataService.GetAsync(applicationId, source, bureau);

            return result == null ? Ok("No credit data found") : Ok(result);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Error retreiving data");
            return Problem("Error Retreicing data");
        }
    }
}

