namespace AADemo.Domain.Models;

public class Tradeline
{
    public int TradelineId { get; set; }
    public string? AccountNumber { get; set; }
    public decimal Balance { get; set; }
    public decimal MonthlyPayment { get; set; }
    public string? Type { get; set; }
    public bool IsMortgage { get; set; }
}
