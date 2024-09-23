using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.CompanyEntities;
using System.Linq;

namespace bizyeriz.Application.Features.Companies.Queries.GetAllCompanies;

public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, GetAllCompaniesQueryResponse>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;
    public GetAllCompaniesQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
    }


    public async Task<GetAllCompaniesQueryResponse> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        List<Company> companies =  _companyRepository.GetAll().ToListAsync();
        var result =  _mapper.Map<GetAllCompaniesQueryResponse>(companies);  
        return
    }
}
