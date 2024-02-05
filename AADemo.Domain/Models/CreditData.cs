namespace AADemo.Domain.Models;

public class CreditData
{
	public int ApplicationId { get; set; }
	public string? CustomerName { get; set; }
	public string? Source { get; set; }
	public string? Bureau { get; set; }
	public decimal MinPaymentPercentage { get; set; }
	public List<Tradeline> Tradelines { get; set; } = new List<Tradeline>();
}