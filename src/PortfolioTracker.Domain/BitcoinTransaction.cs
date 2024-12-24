namespace PortfolioTracker.Domain;

public class BitcoinTransaction
{
    public Guid Id { get; set; }

    public DateTime TransactionDateTime { get; set; }

    public decimal? BtcAmount { get; set; }

    public string? BtcCurrency { get; set; }

    public decimal? FiatPrice { get; set; }

    public string? FiatCurrency { get; set; }

    public string? Notes { get; set; }
}