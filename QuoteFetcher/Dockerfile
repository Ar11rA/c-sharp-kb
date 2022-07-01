FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["QuoteFetcher/QuoteFetcher.csproj", "QuoteFetcher/"]
RUN dotnet restore "QuoteFetcher/QuoteFetcher.csproj"
COPY . .
WORKDIR "/src/QuoteFetcher"
RUN dotnet build "QuoteFetcher.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QuoteFetcher.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QuoteFetcher.dll"]
