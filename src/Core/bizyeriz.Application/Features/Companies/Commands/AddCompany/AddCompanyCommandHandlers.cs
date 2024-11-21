using AutoMapper;
using bizyeriz.Application.Features.Companies.BusinessRules;
using bizyeriz.Application.Interfaces.Repositories;
using bizyeriz.Application.Interfaces.UnitOfWork;
using bizYeriz.Domain.Entities.CompanyEntities;
using NetTopologySuite.Geometries;

namespace bizyeriz.Application.Features.Companies.Commands.AddCompany;

public class AddCompanyCommandHandlers : IRequestHandler<AddCompanyCommand, AddCompanyCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly CompanyBusinessRules _businessRules;

    public AddCompanyCommandHandlers(IMapper mapper, ICompanyRepository companyRepository, IUnitOfWork unitOfWork, CompanyBusinessRules businessRules)
    {
        _mapper = mapper;
        _companyRepository = companyRepository;
        _unitOfWork = unitOfWork;
        _businessRules = businessRules;
    }

    public async Task<AddCompanyCommandResponse> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
    {
        Company company = _mapper.Map<Company>(request);
        await _businessRules.CheckIfCompanyIsNull(company);
        company.CreatedDate = DateTime.UtcNow;       
        company.Location = new Point(request.Long, request.Lat);

        try
        {
            Company addedCompany = await _companyRepository.AddAsync(company, cancellationToken);
            await _unitOfWork.CommitAsync();
            AddCompanyCommandResponse response = _mapper.Map<AddCompanyCommandResponse>(addedCompany);
            return response;
        }
        catch (Exception ex)
        {
            // Log the full exception here (especially the inner exception)
            throw new Exception("An error occurred while saving the entity changes.", ex);
        }

    }
}
