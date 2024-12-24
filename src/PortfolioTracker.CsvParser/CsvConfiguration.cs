using System.Globalization;
using CsvHelper.Configuration;

namespace PortfolioTracker.CsvParser;

internal static class CsvConfigurationProvider
{
    public static CsvConfiguration GetDefaultConfiguration()
    {
        return new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            TrimOptions = TrimOptions.Trim,
            MissingFieldFound = null,
            BadDataFound = null
        };
    }
}