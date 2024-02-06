using System.Net.Http.Json;
using System.Text.Json;
using AADemo.Domain.Entities;
using AADemo.Domain.Models;
using Microsoft.Extensions.Logging;

namespace AADemo.Infrastructure.Services;

public class CreditDataService: ICreditDataService
{
    private readonly ILogger<CreditDataService> _logger;
    private readonly string _dataUrl = "https://raw.githubusercontent.com/StrategicFS/Recruitment/master/creditData.json";
    private readonly IHttpClientFactory _httpClientFactory;

    public CreditDataService(ILogger<CreditDataService> logger, IHttpClientFactory clientFactory)
	{
        _logger = logger;
        _httpClientFactory = clientFactory;
    }

    public async Task<CreditData?> GetAsync(long? applicationId, string? source, string? bureau)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetFromJsonAsync<UrlResponse>(_dataUrl);
            var data = response?.CreditReports.AsEnumerable();

            var creditReport = data?.First(d =>
            d.ApplicationId == applicationId &&
            d.Source == source &&
            d.Bureau == bureau);

            return creditReport;
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Error retreiving JSON data");
            return null;
        }

    }

    public async Task<CreditData?> GetAsync(long? applicationId)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            var data = await client.GetFromJsonAsync<UrlResponse>(_dataUrl);

            return (CreditData?)data?.CreditReports.Where(d => d.ApplicationId == applicationId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retreiving JSON data");
            return null;
        }

    }
}
