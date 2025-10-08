using AvalphaTechnologies.CommissionCalculator.DTOs;

namespace AvalphaTechnologies.CommissionCalculator.Services;

public interface ICommissionService
{
    CommissionResponse Calculate(CommissionRequest request);
}