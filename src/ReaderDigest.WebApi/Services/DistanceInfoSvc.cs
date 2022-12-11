
using System.Text.Json;

namespace ReaderDigest.WebApi.Services;

public interface IDistanceInfoSvc
{
    Task<(int, string)> GetDistanceAsync(string originCity, string destinationCity);
}

public class DistanceInfoSvc : IDistanceInfoSvc
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DistanceInfoSvc(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<(int, string)> GetDistanceAsync(string originCity, string destinationCity)
    {
        var httpClient = _httpClientFactory.CreateClient("DistanceMicroservice");
        var microserviceUtl = $"?originCity={originCity}&destinationCity={destinationCity}";
        var responseStream = await httpClient.GetStreamAsync(microserviceUtl);
        var distanceData = await JsonSerializer.DeserializeAsync<MapDistanceInfo>(responseStream);
        var distance = 0;
        var distanceType = "";
        foreach (var row in distanceData.rows)
        {
            foreach (var element in row.elements)
            {
                if (int.TryParse(CleanDistanceInfo(element.distance.text), out var distanceConverted))
                {
                    distance += distanceConverted;
                    if (element.distance.text.EndsWith("mi"))
                    {
                        distanceType = "miles";
                    }

                    if (element.distance.text.EndsWith("km"))
                    {
                        distanceType = "kilometers";
                    }
                }
            }
        }

        return (distance, distanceType);
    }
    
    private string CleanDistanceInfo(string value)
    {
    {
        return value.Replace("mi", "").Replace("km", "").Replace(",", "");
    }}
}