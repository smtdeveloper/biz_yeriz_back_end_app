using bizyeriz.Application.Features.Companies.Models;
using bizyeriz.Application.Features.Companies.Queries.GetNearbyCompanies;
using bizYeriz.Shared.Responses;

public class GetFilterNearbyCompaniesQuery : IRequest<IDataResponse<List<GetFilterNearbyCompaniesQueryResponse>>>
{
    public LocationDto Location { get; set; }
    public FilterCompaniesDto Filters { get; set; } = new FilterCompaniesDto();

    public GetFilterNearbyCompaniesQuery() { }

    public GetFilterNearbyCompaniesQuery(LocationDto location, FilterCompaniesDto filters)
    {
        Location = location;
        Filters = filters;
    }
}