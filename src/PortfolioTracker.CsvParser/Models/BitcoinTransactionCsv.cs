using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace PortfolioTracker.CsvParser.Models;

public class BitcoinTransactionCsv
{
    [Required]
    [Name("Transaction ID")]
    public Guid TransactionId { get; set; }

    [Required]
    [Name("Completed Date (UTC)")]
    public DateTime Date { get; set; }
    
    [Required]
    [Name("Completed Time (UTC)")]
    public TimeSpan Time { get; set; } 

    [Name("Amount 2")]
    public decimal? BtcAmount { get; set; }

    [Name("Currency 2")]
    public string? BtcCurrency { get; set; }

    [Name("Amount 1")]
    public decimal? FiatPrice { get; set; }
    
    [Name("Fee 1")]
    public decimal? FiatFee { get; set; }

    [Name("Currency 1")]
    public string? FiatCurrency { get; set; }

    [Name("Description")]
    public string? Notes { get; set; }
}