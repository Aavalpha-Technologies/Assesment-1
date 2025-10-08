using Microsoft.AspNetCore.Mvc;
using AvalphaTechnologies.CommissionCalculator.DTOs;
using AvalphaTechnologies.CommissionCalculator.Services;

namespace AvalphaTechnologies.CommissionCalculator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommissionController : ControllerBase
{
    private readonly ICommissionService _commissionService;

    public CommissionController(ICommissionService commissionService)
    {
        _commissionService = commissionService;
    }

    [HttpPost("calculate")]
    [ProducesResponseType(typeof(CommissionResponse), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Calculate([FromBody] CommissionRequest request)
    {
        try
        {
            var result = _commissionService.Calculate(request);
            return Ok(result);
        }
        catch (Exception)
        {
            // In a real app, log the exception `ex` with a logging framework
            return StatusCode(500, new { message = "An unexpected error occurred." });
        }
    }
}