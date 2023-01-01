
using Microsoft.AspNetCore.Mvc;
using ReaderDigest.WebApi.Models;
using ReaderDigest.WebApi.Services;

namespace ReaderDigest.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MapInfoController : ControllerBase
{
    private readonly IQuoteSvc _quoteSvc;

    public MapInfoController(IQuoteSvc distanceService)
    {
        _quoteSvc = distanceService;
    }
    [HttpGet()]
    public async Task<Quote> GetDistance(string originCity, string destinationCity)
    {
        return await _quoteSvc.CreateQuoteAsync(originCity, destinationCity);
    }
}