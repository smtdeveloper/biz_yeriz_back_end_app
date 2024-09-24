
using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;

namespace bizyeriz.Application.Features.Companies.Commands.DeleteCompany;

public class DeleteCompanyQueryHandler : IRequestHandler<DeleteCompanyQuery, DeleteCompanyQueryResponse>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;

    public DeleteCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
    }

    public async Task<DeleteCompanyQueryResponse> Handle(DeleteCompanyQuery request, CancellationToken cancellationToken)
    {
        var company = await _companyRepository.GetByIdAsync(request.Id, cancellationToken);
        _companyRepository.Remove(company);
        DeleteCompanyQueryResponse response = _mapper.Map<DeleteCompanyQueryResponse>(company);
        return response;
    }
}
