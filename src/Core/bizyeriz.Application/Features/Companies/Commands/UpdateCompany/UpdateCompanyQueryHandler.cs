using AutoMapper;
using bizyeriz.Application.Features.Companies.BusinessRules;
using bizyeriz.Application.Interfaces.Repositories;

namespace bizyeriz.Application.Features.Companies.Commands.UpdateCompany;

public class UpdateCompanyQueryHandler : IRequestHandler<UpdateCompanyQuery, UpdateCompanyQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly ICompanyRepository _companyRepository;
    private readonly CompanyBusinessRules _businessRules;

    public UpdateCompanyQueryHandler(IMapper mapper, ICompanyRepository companyRepository, CompanyBusinessRules businessRules)
    {
        _mapper = mapper;
        _companyRepository = companyRepository;
        _businessRules = businessRules;
    }

    public async Task<UpdateCompanyQueryResponse> Handle(UpdateCompanyQuery request, CancellationToken cancellationToken)
    {    
        var company = await _companyRepository.GetByIdAsync(request.Id, cancellationToken);
        await _businessRules.CheckIfCompanyIsNull(company);
        
        company = _mapper.Map(request, company);
        var updatedCompany =  await _companyRepository.Update(company!);
        
        await _businessRules.CheckIfCompanyIsNull(updatedCompany);
        
        UpdateCompanyQueryResponse response = _mapper.Map<UpdateCompanyQueryResponse>(company);
        return response;
    }
}
