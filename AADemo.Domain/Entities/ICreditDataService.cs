using AADemo.Domain.Models;

namespace AADemo.Domain.Entities;

public interface ICreditDataService
{
    Task<CreditData?> GetAsync(int? applicationId, string? source, string? bureau);
    Task<CreditData?> GetAsync(int? applicationId);
}
