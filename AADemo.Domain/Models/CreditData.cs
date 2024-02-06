﻿namespace AADemo.Domain.Models;

public class CreditData
{
	public long ApplicationId { get; set; }
	public string CustomerName { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string Bureau { get; set; } = string.Empty;
    public decimal MinPaymentPercentage { get; set; }
	public IList<Tradeline> Tradelines { get; set; } = new List<Tradeline>();
}