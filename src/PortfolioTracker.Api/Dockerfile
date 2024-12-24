FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PortfolioTracker.Api/PortfolioTracker.Api.csproj", "PortfolioTracker.Api/"]
COPY ["PortfolioTracker.Logging/PortfolioTracker.Logging.csproj", "PortfolioTracker.Logging/"]
RUN dotnet restore "PortfolioTracker.Api/PortfolioTracker.Api.csproj"
COPY . .
WORKDIR "/src/PortfolioTracker.Api"
RUN dotnet build "PortfolioTracker.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PortfolioTracker.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false /p:DebugType=None /p:DebugSymbols=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PortfolioTracker.Api.dll"]
