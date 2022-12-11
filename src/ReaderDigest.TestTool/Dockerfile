FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ReaderDigest.TestTool/ReaderDigest.TestTool.csproj", "ReaderDigest.TestTool/"]
RUN dotnet restore "ReaderDigest.TestTool/ReaderDigest.TestTool.csproj"
COPY . .
WORKDIR "/src/ReaderDigest.TestTool"
RUN dotnet build "ReaderDigest.TestTool.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReaderDigest.TestTool.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReaderDigest.TestTool.dll"]
