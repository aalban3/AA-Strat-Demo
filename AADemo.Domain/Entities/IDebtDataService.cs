using AADemo.Domain.Models;

namespace AADemo.Domain.Entities;

public interface IDebtDataService
{
    Task<DebtData?> GetAsync(long? applicationId, decimal? annualIncome);
}