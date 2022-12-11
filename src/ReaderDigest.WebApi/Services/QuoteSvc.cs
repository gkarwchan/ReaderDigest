
using ReaderDigest.WebApi.Models;

namespace ReaderDigest.WebApi.Services;

public class QuoteSvc
{
    private readonly IDistanceInfoSvc _distanceInfoSvc;

    public QuoteSvc(IDistanceInfoSvc distanceInfoSvc)
    {
        _distanceInfoSvc = distanceInfoSvc;
    }

    public async Task<Quote> CreateQuoteAsync(string originCity, string destinationCity)
    {
        var distanceInfo = await _distanceInfoSvc.GetDistanceAsync(originCity, destinationCity);
        var quote = new Quote
        {
            Id = 1, ExpectedDistance = distanceInfo.Item1,
            ExpectedDistanceType = distanceInfo.Item2
        };
        return quote;
    }
}