FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ReaderDigest.GpsService/ReaderDigest.GpsService.csproj", "ReaderDigest.GpsService/"]
RUN dotnet restore "ReaderDigest.GpsService/ReaderDigest.GpsService.csproj"
COPY . .
WORKDIR "/src/ReaderDigest.GpsService"
RUN dotnet build "ReaderDigest.GpsService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReaderDigest.GpsService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReaderDigest.GpsService.dll"]
