using AutoMapper;
using bizyeriz.Application.Features.Companies.BusinessRules;
using bizyeriz.Application.Interfaces.Repositories;
using bizyeriz.Application.Interfaces.UnitOfWork;
using bizYeriz.Domain.Entities.CompanyEntities;

namespace bizyeriz.Application.Features.Companies.Commands.DeleteCompany;

public class DeleteCompanyQueryHandler : IRequestHandler<DeleteCompanyQuery, DeleteCompanyQueryResponse>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly CompanyBusinessRules _companyBusinessRules;
    public DeleteCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper, IUnitOfWork unitOfWork, CompanyBusinessRules companyBusinessRules)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _companyBusinessRules = companyBusinessRules;
    }

    public async Task<DeleteCompanyQueryResponse> Handle(DeleteCompanyQuery request, CancellationToken cancellationToken)
    {
        Company company = await _companyRepository.GetByIdAsync(request.Id, cancellationToken);
        _companyBusinessRules.CheckIfCompanyIsNull(company);
        _companyRepository.Remove(company);        
        await _unitOfWork.CommitAsync();
        DeleteCompanyQueryResponse response = _mapper.Map<DeleteCompanyQueryResponse>(company);
        return response;
    }
}
