namespace AADemo.Domain.Models;

public class UrlResponse
{
    public IList<CreditData> CreditReports { get; set; } = new List<CreditData>();
}
