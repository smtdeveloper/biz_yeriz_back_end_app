namespace bizyeriz.Application.Features.Companies.Queries.GetNearbyCompanies;

public class GetNearbyCompaniesQuery : IRequest<List<GetNearbyCompaniesQueryResponse>>
{
    public double Latitude { get; }
    public double Longitude { get; }
    public double Distance { get; }

    public GetNearbyCompaniesQuery(double latitude, double longitude, double distance)
    {
        Latitude = latitude;
        Longitude = longitude;
        Distance = distance;
    }
}

