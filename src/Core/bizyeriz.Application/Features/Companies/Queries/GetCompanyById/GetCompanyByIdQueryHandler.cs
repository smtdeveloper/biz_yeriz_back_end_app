using AutoMapper;
using bizyeriz.Application.Features.Companies.BusinessRules;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.CompanyEntities;
using bizYeriz.Shared.Responses;

namespace bizyeriz.Application.Features.Companies.Queries.GetCompanyById;

public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, IDataResponse<GetCompanyByIdQueryResponse>>
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

    public async Task<IDataResponse<GetCompanyByIdQueryResponse>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var company = await _companyRepository.GetByIdAsync(request.Id, cancellationToken);
        await _companyBusinessRules.CheckIfCompanyIsNull(company);

        List<CuisineCategoryWithFoodsDto> groupedFoods = await _companyRepository.GetFoodsGroupedByCuisineAsync(request.Id, cancellationToken);
        List<CompanyWorkingHour> workingHours = await _companyRepository.GetWorkingHoursByCompanyIdAsync(request.Id, cancellationToken);

        GetCompanyByIdQueryResponse response = _mapper.Map<GetCompanyByIdQueryResponse>(company);
        response.CuisineCategoriesWithFoods = groupedFoods;
        response.WorkingHours = _mapper.Map<List<CompanyWorkingHourDto>>(workingHours);

        var result = DataResponse<GetCompanyByIdQueryResponse>.SuccessResponse(response, "Şirket Başarıyla Listendi.");
        return result;
    }

}