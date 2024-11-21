using AutoMapper;
using bizyeriz.Application.Features.Companies.BusinessRules;
using bizyeriz.Application.Interfaces.Repositories;

namespace bizyeriz.Application.Features.Companies.Queries.GetCompanyById;

public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, GetCompanyByIdQueryResponse>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;
    private readonly CompanyBusinessRules _companyBusinessRules;
    public GetCompanyByIdQueryHandler(ICompanyRepository companyRepository, IMapper mapper, CompanyBusinessRules companyBusinessRules)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
        _companyBusinessRules = companyBusinessRules;
    }


    public async Task<GetCompanyByIdQueryResponse> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var company = await _companyRepository.GetByIdAsync(request.Id, cancellationToken);
        await _companyBusinessRules.CheckIfCompanyIsNull(company);
        return _mapper.Map<GetCompanyByIdQueryResponse>(company);
    }
}
