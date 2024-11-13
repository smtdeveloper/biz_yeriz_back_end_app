using AutoMapper;
using bizyeriz.Application.Features.Companies.BusinessRules;
using bizyeriz.Application.Interfaces.Repositories;
using bizyeriz.Application.Interfaces.UnitOfWork;
using bizYeriz.Domain.Entities.CompanyEntities;

namespace bizyeriz.Application.Features.Companies.Commands.DeleteCompany;

public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, DeleteCompanyCommandResponse>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly CompanyBusinessRules _companyBusinessRules;
    public DeleteCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper, IUnitOfWork unitOfWork, CompanyBusinessRules companyBusinessRules)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _companyBusinessRules = companyBusinessRules;
    }

    public async Task<DeleteCompanyCommandResponse> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        Company company = await _companyRepository.GetByIdAsync(request.Id, cancellationToken);
        _companyBusinessRules.CheckIfCompanyIsNull(company);
        _companyRepository.Remove(company);        
        await _unitOfWork.CommitAsync();
        DeleteCompanyCommandResponse response = _mapper.Map<DeleteCompanyCommandResponse>(company);
        return response;
    }
}
