using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using bizyeriz.Application.Interfaces.UnitOfWork;

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
        var company = await _companyRepository.GetByIdAsync(request.Id, cancellationToken);
        _companyRepository.Remove(company);
        _unitOfWork.CommitAsync();
        DeleteCompanyQueryResponse response = _mapper.Map<DeleteCompanyQueryResponse>(company);
        return response;
    }
}
