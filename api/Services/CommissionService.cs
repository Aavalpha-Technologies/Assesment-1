public class CommissionService
{
    private const decimal AvalphaLocalRate = 0.20m;      // 20%
    private const decimal AvalphaForeignRate = 0.35m;    // 35%
    private const decimal CompetitorLocalRate = 0.02m;   // 2%
    private const decimal CompetitorForeignRate = 0.0755m; // 7.55%

    public CommissionResponse Calculate(int localSales, int foreignSales, decimal avgAmount)
    {
        var avalphaLocal = localSales * avgAmount * AvalphaLocalRate;
        var avalphaForeign = foreignSales * avgAmount * AvalphaForeignRate;
        var avalphaTotal = avalphaLocal + avalphaForeign;

        var competitorLocal = localSales * avgAmount * CompetitorLocalRate;
        var competitorForeign = foreignSales * avgAmount * CompetitorForeignRate;
        var competitorTotal = competitorLocal + competitorForeign;

        return new CommissionResponse
        {
            AvalphaLocal = avalphaLocal,
            AvalphaForeign = avalphaForeign,
            AvalphaTotal = avalphaTotal,
            CompetitorLocal = competitorLocal,
            CompetitorForeign = competitorForeign,
            CompetitorTotal = competitorTotal
        };
    }
}
