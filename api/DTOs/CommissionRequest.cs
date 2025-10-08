using System.ComponentModel.DataAnnotations;

namespace AvalphaTechnologies.CommissionCalculator.DTOs;
// rules for data coming into api
public record CommissionRequest(
    [Required]
    [Range(0, 1_000_000)]
    int LocalSalesCount,

    [Required]
    [Range(0, 1_000_000)]
    int ForeignSalesCount,

    [Required]
    [Range(0.01, 10_000_000)]
    decimal AverageSaleAmount
);