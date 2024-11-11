using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using bizyeriz.Application.Interfaces.UnitOfWork;
using bizYeriz.Domain.Entities.CompanyEntities;

namespace bizyeriz.Application.Features.Companies.Commands.DeleteCompany;

public class DeleteCompanyQueryHandler : IRequestHandler<DeleteCompanyQuery, DeleteCompanyQueryResponse>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteCompanyQueryResponse> Handle(DeleteCompanyQuery request, CancellationToken cancellationToken)
    {
        Company company = await _companyRepository.GetByIdAsync(request.Id, cancellationToken);

        if (company == null)
        {
            throw new Exception("Company not found.");
        }

        _companyRepository.Remove(company);
        await _unitOfWork.CommitAsync();
        DeleteCompanyQueryResponse response = _mapper.Map<DeleteCompanyQueryResponse>(company);
        return response;
    }
}
