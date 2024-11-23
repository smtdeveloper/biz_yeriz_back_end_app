using bizyeriz.Application.Features.Companies.Models;
using bizyeriz.Application.Features.Companies.Queries.GetNearbyCompanies;
using System.Text.Json.Serialization;

public class GetFilterNearbyCompaniesQuery : IRequest<List<GetFilterNearbyCompaniesQueryResponse>>
{
    public LocationDto Location { get; set; }
    public FilterCompaniesDto? Filters { get; set; } = new FilterCompaniesDto();

    public GetFilterNearbyCompaniesQuery() { }

    public GetFilterNearbyCompaniesQuery(LocationDto location, FilterCompaniesDto? filters)
    {
        Location = location;
        Filters = filters;  
    }
}