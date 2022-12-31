
using Grpc.Net.Client;
using ReaderDigest.LocationService;
using ReaderDigest.WebApi.Models;

namespace ReaderDigest.WebApi.Services;

public interface IDistanceInfoSvc
{
    Task<(int, string)> GetDistanceAsync(string originCity, string destinationCity);
}

public class DistanceInfoSvc : IDistanceInfoSvc
{

    public async Task<(int, string)> GetDistanceAsync(string originCity, string destinationCity)
    {
        var channel = GrpcChannel.ForAddress(new Uri("https://localhost:7074"));
        var client = new DistanceInfo.DistanceInfoClient(channel);
        var response = await client.GetDistanceAsync(new Cities {OriginCity = originCity, DestinationCity = destinationCity});
        if (int.TryParse(CleanDistanceInfo(response.Miles), out var dist))
        {
            return (dist, response.Miles[^2..]);
        }

        throw new ArgumentException("Cannot read the value");
    }
    
    private string CleanDistanceInfo(string value)
    {
    {
        return value.Replace("mi", "").Replace("km", "").Replace(",", "");
    }}
}