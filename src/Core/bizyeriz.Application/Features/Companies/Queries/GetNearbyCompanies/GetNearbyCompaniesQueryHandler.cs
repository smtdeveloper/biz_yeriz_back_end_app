using AutoMapper;
using bizyeriz.Application.Features.Companies.Queries.GetAllCompanies;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.CompanyEntities;
using System.Linq.Expressions;

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
        var companies = await _companyRepository.GetNearbyCompaniesAsync(latitude: request.Latitude, longitude : request.Latitude, distance : request.Distance, cancellationToken);
        return _mapper.Map<List<GetNearbyCompaniesQueryResponse>>(companies);
    }
}

