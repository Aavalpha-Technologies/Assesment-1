using AvalphaTechnologies.CommissionCalculator.DTOs;

namespace AvalphaTechnologies.CommissionCalculator.Services;

public class CommissionService : ICommissionService
{
    private const decimal AvalphaLocalRate = 0.20m;
    private const decimal AvalphaForeignRate = 0.35m;
    private const decimal CompetitorLocalRate = 0.02m;
    private const decimal CompetitorForeignRate = 0.0755m;

    public CommissionResponse Calculate(CommissionRequest request)
    {
        decimal totalLocalSales = request.LocalSalesCount * request.AverageSaleAmount;
        decimal totalForeignSales = request.ForeignSalesCount * request.AverageSaleAmount;

        var avalphaCommission = new CommissionDetails
        {
            Local = totalLocalSales * AvalphaLocalRate,
            Foreign = totalForeignSales * AvalphaForeignRate
        };

        var competitorCommission = new CommissionDetails
        {
            Local = totalLocalSales * CompetitorLocalRate,
            Foreign = totalForeignSales * CompetitorForeignRate
        };

        return new CommissionResponse
        {
            AvalphaCommission = avalphaCommission,
            CompetitorCommission = competitorCommission
        };
    }
}