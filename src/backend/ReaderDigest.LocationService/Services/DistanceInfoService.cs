
using Grpc.Core;
using ReaderDigest.GoogleMapInfo;

namespace ReaderDigest.LocationService.Services;

public class DistanceInfoService : DistanceInfo.DistanceInfoBase
{
    private readonly GoogleDistanceService _distanceService;

    public DistanceInfoService(GoogleDistanceService distanceService)
    {
        _distanceService = distanceService;
    }
    
    public override async Task<DistanceData> GetDistance(Cities cities, ServerCallContext context)
    {
        var totalMiles = "0";
        var distanceData = await _distanceService.GetMapDistance(cities.OriginCity, cities.DestinationCity);
        foreach (var distanceDataRow in distanceData.rows)
        {
            foreach (var element in distanceDataRow.elements)
            {
                totalMiles = element.distance.text;
            }
        }
        return new DistanceData { Miles = totalMiles};
    }
}