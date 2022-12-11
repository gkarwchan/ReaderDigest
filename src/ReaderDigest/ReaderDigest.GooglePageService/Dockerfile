FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ReaderDigest.GooglePageService/ReaderDigest.GooglePageService.csproj", "ReaderDigest.GooglePageService/"]
RUN dotnet restore "ReaderDigest.GooglePageService/ReaderDigest.GooglePageService.csproj"
COPY . .
WORKDIR "/src/ReaderDigest.GooglePageService"
RUN dotnet build "ReaderDigest.GooglePageService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReaderDigest.GooglePageService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReaderDigest.GooglePageService.dll"]
