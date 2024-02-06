namespace AADemo.Domain.Models;

public class UrlResponse
{
    public IList<CreditData> CreditReports { get; } = new List<CreditData>();
}
