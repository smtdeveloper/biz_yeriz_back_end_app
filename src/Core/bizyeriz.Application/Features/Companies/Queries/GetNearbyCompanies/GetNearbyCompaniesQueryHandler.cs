using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;

namespace bizyeriz.Application.Features.Companies.Queries.GetNearbyCompanies;

public class GetNearbyCompaniesQueryHandler : IRequestHandler<GetNearbyCompaniesQuery, List<GetNearbyCompaniesQueryResponse>>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;

    public GetNearbyCompaniesQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
    }

    public async Task<List<GetNearbyCompaniesQueryResponse>> Handle(GetNearbyCompaniesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _companyRepository.GetNearbyCompaniesAsync(request.Latitude, request.Longitude, request.Distance, cancellationToken);
        return _mapper.Map<List<GetNearbyCompaniesQueryResponse>>(companies);        
    }

}

