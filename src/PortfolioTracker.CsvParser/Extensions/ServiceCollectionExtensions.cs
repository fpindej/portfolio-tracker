using Microsoft.Extensions.DependencyInjection;
using PortfolioTracker.CsvParser.Services;

namespace PortfolioTracker.CsvParser.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCsvParsing(this IServiceCollection services)
    {
        services.AddSingleton<CsvParsingService>();

        return services;
    }
}