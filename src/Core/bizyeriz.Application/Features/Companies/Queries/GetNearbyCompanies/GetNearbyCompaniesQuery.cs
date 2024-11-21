using bizyeriz.Application.Features.Companies.Queries.GetNearbyCompanies;
using System.Text.Json.Serialization;

public class GetNearbyCompaniesQuery : IRequest<List<GetNearbyCompaniesQueryResponse>>
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("distance")]
    public double Distance { get; set; }   

    public GetNearbyCompaniesQuery() { }

    public GetNearbyCompaniesQuery(double latitude, double longitude, double distance)
    {
        Latitude = latitude;
        Longitude = longitude;
        Distance = distance;
    }
}
