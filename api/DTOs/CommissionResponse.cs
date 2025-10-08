namespace AvalphaTechnologies.CommissionCalculator.DTOs;
// data api will sent back to frontend
public record CommissionResponse
{
    public required CommissionDetails AvalphaCommission { get; init; }
    public required CommissionDetails CompetitorCommission { get; init; }
}

public record CommissionDetails
{
    public decimal Local { get; init; }
    public decimal Foreign { get; init; }
    public decimal Total => Local + Foreign;
}