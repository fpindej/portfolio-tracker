using System.Collections.Immutable;
using CsvHelper;
using CsvHelper.Configuration;

namespace PortfolioTracker.CsvParser.Services;

public class CsvParsingService
{
    public IReadOnlyList<T> FromCsv<T>(Stream csvStream, CsvConfiguration? customConfiguration = null)
    {
        var config = customConfiguration ?? CsvConfigurationProvider.GetDefaultConfiguration();

        using var reader = new StreamReader(csvStream);
        using var csv = new CsvReader(reader, config);

        return csv.GetRecords<T>().ToImmutableList();
    }
}