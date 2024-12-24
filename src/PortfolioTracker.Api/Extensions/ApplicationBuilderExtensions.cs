namespace PortfolioTracker.Api.Extensions;

internal static class ApplicationBuilderExtensions
{
    public static void UseCustomizedSwagger(this IApplicationBuilder builder)
    {
        builder.UseSwagger();
        builder.UseSwaggerUI(opt =>
        {

            opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Portfolio tracker V1");
        });
    }
}