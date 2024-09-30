using AutoMapper;
using bizyeriz.Application.Features.Companies.BusinessRules;
using bizyeriz.Application.Interfaces.Repositories;
using bizyeriz.Application.Interfaces.UnitOfWork;
using bizYeriz.Domain.Entities.CompanyEntities;

namespace bizyeriz.Application.Features.Companies.Commands.AddCompany;

public class AddCompanyQueryHandlers : IRequestHandler<AddCompanyQuery, AddCompanyQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly CompanyBusinessRules _businessRules;

    public AddCompanyQueryHandlers(IMapper mapper, ICompanyRepository companyRepository, IUnitOfWork unitOfWork, CompanyBusinessRules businessRules)
    {
        _mapper = mapper;
        _companyRepository = companyRepository;
        _unitOfWork = unitOfWork;
        _businessRules = businessRules;
    }

    public async Task<AddCompanyQueryResponse> Handle(AddCompanyQuery request, CancellationToken cancellationToken)
    {
        // Use AutoMapper to map from AddCompanyQuery to Company
        Company company = _mapper.Map<Company>(request);

        // Business rule validation
        await _businessRules.CheckIfCompanyIsNull(company);

        // Add the company to the repository
        var addedCompany = await _companyRepository.AddAsync(company, cancellationToken);

        // Commit changes using UnitOfWork
        await _unitOfWork.CommitAsync();

        // Map the result back to the response type
        AddCompanyQueryResponse response = _mapper.Map<AddCompanyQueryResponse>(addedCompany);
        return response;
    }
}
