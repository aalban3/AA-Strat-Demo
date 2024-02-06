using AADemo.Domain.Models;

namespace AADemo.Domain.Entities;

public interface ICreditDataService
{
    Task<CreditData?> GetAsync(long? applicationId, string? source, string? bureau);
    Task<CreditData?> GetAsync(long? applicationId);
}
