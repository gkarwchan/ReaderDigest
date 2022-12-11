FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ReaderDigest.WebApi/ReaderDigest.WebApi.csproj", "ReaderDigest.WebApi/"]
RUN dotnet restore "ReaderDigest.WebApi/ReaderDigest.WebApi.csproj"
COPY . .
WORKDIR "/src/ReaderDigest.WebApi"
RUN dotnet build "ReaderDigest.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReaderDigest.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReaderDigest.WebApi.dll"]
