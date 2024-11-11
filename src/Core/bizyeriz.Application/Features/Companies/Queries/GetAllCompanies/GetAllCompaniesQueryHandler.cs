using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.CompanyEntities;

namespace bizyeriz.Application.Features.Companies.Queries.GetAllCompanies;

public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, List<GetAllCompaniesQueryResponse>>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;

    public GetAllCompaniesQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllCompaniesQueryResponse>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _companyRepository.GetAllAsync<GetAllCompaniesQueryResponse>(cancellationToken);
        return companies.ToList();
    }
}
