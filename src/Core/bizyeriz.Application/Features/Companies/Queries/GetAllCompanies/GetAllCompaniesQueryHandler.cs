using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Shared.Responses;
using System.Linq.Expressions;

namespace bizyeriz.Application.Features.Companies.Queries.GetAllCompanies;

public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, IDataResponse<List<GetAllCompaniesQueryResponse>>>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;

    public GetAllCompaniesQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
    }

    public async Task<IDataResponse<List<GetAllCompaniesQueryResponse>>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<GetAllCompaniesQueryResponse, bool>> filter = companyDto => companyDto.IsActive && !companyDto.IsDelete;

        var response = await _companyRepository.GetAllAsync<GetAllCompaniesQueryResponse>(cancellationToken, filter);
        var responseList = response.ToList();

        var result = DataResponse<List<GetAllCompaniesQueryResponse>>.SuccessResponse(responseList, "Şirketler başarıyla Listelendi.");
        return result;
    }
}