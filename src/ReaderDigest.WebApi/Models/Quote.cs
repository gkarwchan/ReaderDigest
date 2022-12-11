
namespace ReaderDigest.WebApi.Models;

public class Quote
{
    public int Id { get; set; }
    public long ExpectedDistance { get; set; }
    public string ExpectedDistanceType { get; set; }
}