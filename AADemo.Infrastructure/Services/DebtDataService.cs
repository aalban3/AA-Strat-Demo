using AADemo.Domain.Entities;
using AADemo.Domain.Models;
using Microsoft.Extensions.Logging;

namespace AADemo.Infrastructure.Services;

public class DebtDataService: IDebtDataService
{
	private readonly ILogger<DebtDataService> _logger;
	private readonly ICreditDataService _creditDataService;

	public DebtDataService(ILogger<DebtDataService> logger, ICreditDataService creditDataService)
	{
		_creditDataService = creditDataService;
		_logger = logger;
    }

	public async Task<DebtData?> GetAsync(int applicationId, decimal annualIncome)
	{
		try
		{
            var data = await _creditDataService.GetAsync(applicationId);
            if (data == null)
                return null;

            var debts = data.Tradelines.Where(t => t.Type == "UNSECURED");
            var debtBalance = debts.Aggregate(0m, (total, val) => total += val.Balance);
            var dti = debtBalance / annualIncome;

            var result = new DebtData
            {
                UnsecuredTradelines = debts.Count(),
                UnsecuredDebtBalance = debtBalance,
                DTI = dti
            };

            return result;
        }
		catch (Exception ex)
		{
            _logger.LogError(ex, "Error Retreiving data to calculate values");
            return null;
		}
	}

}


