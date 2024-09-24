using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.CompanyEntities;

namespace bizyeriz.Application.Features.Companies.Commands.AddCompany;

public class AddCompanyQueryHandlers : IRequestHandler<AddCompanyQuery, AddCompanyQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly ICompanyRepository _companyRepository;

    public AddCompanyQueryHandlers(IMapper mapper, ICompanyRepository companyRepository)
    {
        _mapper = mapper;
        _companyRepository = companyRepository;
    }

    public async Task<AddCompanyQueryResponse> Handle(AddCompanyQuery request, CancellationToken cancellationToken)
    {
        Company company = _mapper.Map<Company>(request);

        company.IsActive = true;
        company.IsDelete = false;

        AddCompanyQueryResponse response =  _mapper.Map<AddCompanyQueryResponse>(company);
        return response;
    }
}
