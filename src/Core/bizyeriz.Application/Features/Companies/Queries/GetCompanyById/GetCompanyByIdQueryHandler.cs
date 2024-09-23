using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;

namespace bizyeriz.Application.Features.Companies.Queries.GetCompanyById;

public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, GetCompanyByIdQueryResponse>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;
    public GetCompanyByIdQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
    }


    public async Task<GetCompanyByIdQueryResponse> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var company = await _companyRepository.GetByIdAsync(request.Id, cancellationToken);
        return _mapper.Map<GetCompanyByIdQueryResponse>(company);
    }
}
