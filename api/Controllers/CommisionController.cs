using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace AvalphaTechnologies.CommissionCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommissionController : ControllerBase
    {
        public class CommissionInput
        {
            [Required(ErrorMessage = "Local sales count is required")]
            [Range(0, 1000000, ErrorMessage = "Local sales count must be between 0 and 1,000,000")]
            public int LocalSalesCount { get; set; }

            [Required(ErrorMessage = "Foreign sales count is required")]
            [Range(0, 1000000, ErrorMessage = "Foreign sales count must be between 0 and 1,000,000")]
            public int ForeignSalesCount { get; set; }

            [Required(ErrorMessage = "Average sale amount is required")]
            [Range(0, 1000000, ErrorMessage = "Average sale amount must be between 0 and 1,000,000")]
            public decimal AverageSaleAmount { get; set; }
        }

        public class CommissionResult
        {
            public decimal AvalphaLocal { get; set; }
            public decimal AvalphaForeign { get; set; }
            public decimal AvalphaTotal { get; set; }
            public decimal CompetitorLocal { get; set; }
            public decimal CompetitorForeign { get; set; }
            public decimal CompetitorTotal { get; set; }
        }

        [HttpPost]
        public IActionResult Calculate([FromBody] CommissionInput input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            decimal avalphaLocal = input.LocalSalesCount * input.AverageSaleAmount * 0.20m;
            decimal avalphaForeign = input.ForeignSalesCount * input.AverageSaleAmount * 0.35m;
            decimal avalphaTotal = avalphaLocal + avalphaForeign;

            decimal competitorLocal = input.LocalSalesCount * input.AverageSaleAmount * 0.02m;
            decimal competitorForeign = input.ForeignSalesCount * input.AverageSaleAmount * 0.0755m;
            decimal competitorTotal = competitorLocal + competitorForeign;

            var result = new CommissionResult
            {
                AvalphaLocal = avalphaLocal,
                AvalphaForeign = avalphaForeign,
                AvalphaTotal = avalphaTotal,
                CompetitorLocal = competitorLocal,
                CompetitorForeign = competitorForeign,
                CompetitorTotal = competitorTotal
            };

            return Ok(result);
        }
    }
}