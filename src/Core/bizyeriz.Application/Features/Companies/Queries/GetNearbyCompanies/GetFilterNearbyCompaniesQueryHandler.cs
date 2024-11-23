using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using NetTopologySuite.Operation.Distance;

namespace bizyeriz.Application.Features.Companies.Queries.GetNearbyCompanies;

public class GetFilterNearbyCompaniesQueryHandler : IRequestHandler<GetFilterNearbyCompaniesQuery, List<GetFilterNearbyCompaniesQueryResponse>>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;

    public GetFilterNearbyCompaniesQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
    }

    public async Task<List<GetFilterNearbyCompaniesQueryResponse>> Handle(GetFilterNearbyCompaniesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _companyRepository.GetFilteredNearbyCompaniesAsync(
           getFilterNearbyCompaniesQuery: request,            
            cancellationToken: cancellationToken);

        var response = _mapper.Map<List<GetFilterNearbyCompaniesQueryResponse>>(companies);
        return response;
    }
}