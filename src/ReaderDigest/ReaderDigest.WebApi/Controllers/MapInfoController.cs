
using Microsoft.AspNetCore.Mvc;
using ReaderDigest.GoogleMapInfo;

namespace ReaderDigest.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MapInfoController : ControllerBase
{
    private readonly GoogleDistanceService _distanceService;

    public MapInfoController(GoogleDistanceService distanceService)
    {
        _distanceService = distanceService;
    }
    [HttpGet()]
    public async Task<GoogleDistanceData> GetDistance(string originCity, string destinationCity)
    {
        return await _distanceService.GetMapDistance(originCity, destinationCity);
    }
}