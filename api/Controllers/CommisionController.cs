using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CommissionController : ControllerBase
{
    private readonly CommissionService _service;

    public CommissionController()
    {
        _service = new CommissionService(); // Can be injected via DI for better design
    }

    [HttpPost]
    public IActionResult Calculate([FromBody] CommissionRequest request)
    {
        var result = _service.Calculate(request.LocalSalesCount, request.ForeignSalesCount, request.AverageSaleAmount);
        return Ok(result);
    }
}
