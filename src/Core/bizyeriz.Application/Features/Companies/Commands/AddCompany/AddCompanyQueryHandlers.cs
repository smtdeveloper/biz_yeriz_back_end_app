using AutoMapper;
using bizyeriz.Application.Features.Companies.BusinessRules;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.CompanyEntities;

namespace bizyeriz.Application.Features.Companies.Commands.AddCompany;

public class AddCompanyQueryHandlers : IRequestHandler<AddCompanyQuery, AddCompanyQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly ICompanyRepository _companyRepository;
    private readonly CompanyBusinessRules _businessRules;

    public AddCompanyQueryHandlers(IMapper mapper, ICompanyRepository companyRepository, CompanyBusinessRules businessRules)
    {
        _mapper = mapper;
        _companyRepository = companyRepository;
        _businessRules = businessRules;
    }

    public async Task<AddCompanyQueryResponse> Handle(AddCompanyQuery request, CancellationToken cancellationToken)
    {
        Company company = _mapper.Map<Company>(request);
        await _businessRules.CheckIfCompanyIsNull(company);

        company.IsActive = true;
        company.IsDelete = false;
        var addedCompany = await _companyRepository.AddAsync(company, cancellationToken);

        await _businessRules.CheckIfCompanyIsNull(addedCompany);
        
        AddCompanyQueryResponse response =  _mapper.Map<AddCompanyQueryResponse>(company);
        return response;
    }
}
