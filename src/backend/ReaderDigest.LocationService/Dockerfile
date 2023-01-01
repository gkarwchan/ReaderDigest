FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001
ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ReaderDigest.LocationService/ReaderDigest.LocationService.csproj", "ReaderDigest.LocationService/"]
RUN dotnet restore "ReaderDigest.LocationService/ReaderDigest.LocationService.csproj"
COPY . .
WORKDIR "/src/ReaderDigest.LocationService"
RUN dotnet build "ReaderDigest.LocationService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReaderDigest.LocationService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReaderDigest.LocationService.dll"]
