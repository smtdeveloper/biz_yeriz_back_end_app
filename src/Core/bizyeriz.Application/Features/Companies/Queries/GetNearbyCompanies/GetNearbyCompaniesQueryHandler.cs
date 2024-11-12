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
        var latitude = request.Latitude;
        var longitude = request.Longitude;       
        var distance = request.Distance;

        var companies = await _companyRepository.GetNearbyCompaniesAsync(latitude, longitude, distance, cancellationToken);
        return _mapper.Map<List<GetNearbyCompaniesQueryResponse>>(companies);
    }
}

