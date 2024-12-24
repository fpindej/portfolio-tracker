using Asp.Versioning;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;

namespace PortfolioTracker.Api.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiDefinition(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Portfolio tracker V1",
                Description = "API V1 for Portfolio Tracker.",
                Version = "v1"
            });

            opt.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
        });

        return services;
    }

    public static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks()
            .AddCheck("Web API", () => HealthCheckResult.Healthy("App is running"), ["ready", "api"]);

        return services;
    }
}