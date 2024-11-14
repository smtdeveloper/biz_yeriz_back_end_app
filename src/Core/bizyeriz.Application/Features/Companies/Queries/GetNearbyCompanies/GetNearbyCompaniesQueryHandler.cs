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
        Expression<Func<GetNearbyCompaniesQueryResponse, bool>> filter = companyDto => companyDto.IsActive && !companyDto.IsDelete;
        var companies = await _companyRepository.GetAllAsync<GetNearbyCompaniesQueryResponse>(cancellationToken, filter);
        return companies.ToList();
    }
}

