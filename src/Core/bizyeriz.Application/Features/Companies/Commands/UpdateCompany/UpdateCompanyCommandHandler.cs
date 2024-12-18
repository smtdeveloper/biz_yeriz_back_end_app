using AutoMapper;
using bizyeriz.Application.Features.Companies.BusinessRules;
using bizyeriz.Application.Interfaces.Repositories;
using bizyeriz.Application.Interfaces.UnitOfWork;
using bizYeriz.Shared.Responses;

namespace bizyeriz.Application.Features.Companies.Commands.UpdateCompany;

public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, IResponse>
{
    private readonly IMapper _mapper;
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitOfWork _unitOfWork; 
    private readonly CompanyBusinessRules _businessRules;

    public UpdateCompanyCommandHandler(IMapper mapper, ICompanyRepository companyRepository, IUnitOfWork unitOfWork, CompanyBusinessRules businessRules)
    {
        _mapper = mapper;
        _companyRepository = companyRepository;
        _unitOfWork = unitOfWork;
        _businessRules = businessRules;
    }

    public async Task<IResponse> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {    
        var company = await _companyRepository.GetByIdAsync(request.Id, cancellationToken);
        await _businessRules.CheckIfCompanyIsNull(company);
        
        company = _mapper.Map(request, company);
        var updatedCompany =  await _companyRepository.Update(company!);
        await _unitOfWork.CommitAsync();
        await _businessRules.CheckIfCompanyIsNull(updatedCompany);

        var result =  Response.SuccessResponse("Şirket Başarıyla Güncellendi.");
        return result;
    }
}