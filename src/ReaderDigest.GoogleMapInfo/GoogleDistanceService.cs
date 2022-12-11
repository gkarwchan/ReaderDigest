
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ReaderDigest.GoogleMapInfo;

public class GoogleDistanceService
{
    private readonly ILogger<GoogleDistanceService> _logger;
    private readonly IConfiguration _configuration;

    
    public GoogleDistanceService(ILogger<GoogleDistanceService> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<GoogleDistanceData> GetMapDistance(string originCity, string destinationCity)
    {
        var apiKey = _configuration["googleDistanceApi:apiKey"];
        var googleDistanceApiUrl = _configuration["googleDistanceApi:apiUrl"];
        googleDistanceApiUrl += $"units=imperial&origins={originCity}&destinations={destinationCity}&key={apiKey}";
        using var client = new HttpClient();
        var request = new
            HttpRequestMessage(HttpMethod.Get, new Uri(googleDistanceApiUrl));
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        await using var data = await response.Content.ReadAsStreamAsync();
        var distanceInfo = await
            JsonSerializer.DeserializeAsync<GoogleDistanceData>(data);
        return distanceInfo;
    }
}