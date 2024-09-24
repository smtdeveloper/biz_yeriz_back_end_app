using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;

namespace bizyeriz.Application.Features.Companies.Commands.UpdateCompany;

public class UpdateCompanyQueryHandler : IRequestHandler<UpdateCompanyQuery, UpdateCompanyQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly ICompanyRepository _companyRepository;

    public UpdateCompanyQueryHandler(IMapper mapper, ICompanyRepository companyRepository)
    {
        _mapper = mapper;
        _companyRepository = companyRepository;
    }

    public async Task<UpdateCompanyQueryResponse> Handle(UpdateCompanyQuery request, CancellationToken cancellationToken)
    {
        var company = await _companyRepository.GetByIdAsync(request.Id, cancellationToken);
        company = _mapper.Map(request, company);
        _companyRepository.Update(company!);

        UpdateCompanyQueryResponse response = _mapper.Map<UpdateCompanyQueryResponse>(company);
        return response;
    }

}
