using AADemo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AADemo.API.Controllers;

[ApiController]
[Route("/api/debt-data")]
public class DebtDataController : ControllerBase
{

    private readonly ILogger<DebtDataController> _logger;
    private readonly IDebtDataService _debtDataService;

    public DebtDataController(ILogger<DebtDataController> logger, IDebtDataService debtDataService)
    {
        _logger = logger;
        _debtDataService = debtDataService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] long? applicationId, [FromQuery] decimal? annualIncome)
    {
        try
        {
            if (applicationId < 1 || annualIncome < 1m)
                return BadRequest("Invalid input values");

            var result = await _debtDataService.GetAsync(applicationId, annualIncome);

            return result == null ? BadRequest("NO available credit data found") : Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retreiving data");
            return Problem("Error Retreiving data");
        }
    }
}

