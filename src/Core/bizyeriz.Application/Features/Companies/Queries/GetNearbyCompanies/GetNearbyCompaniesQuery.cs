using bizyeriz.Application.Features.Companies.Queries.GetNearbyCompanies;

public class GetNearbyCompaniesQuery : IRequest<List<GetNearbyCompaniesQueryResponse>>
{
    public double Latitude { get; set; }   // Added set;
    public double Longitude { get; set; }  // Added set;
    public double Distance { get; set; }   // Added set;

    // Constructor is optional now for deserialization
    public GetNearbyCompaniesQuery() { }

    public GetNearbyCompaniesQuery(double latitude, double longitude, double distance)
    {
        Latitude = latitude;
        Longitude = longitude;
        Distance = distance;
    }
}
