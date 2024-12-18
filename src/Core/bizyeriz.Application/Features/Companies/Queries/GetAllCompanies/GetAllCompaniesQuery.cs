using bizYeriz.Shared.Responses;

namespace bizyeriz.Application.Features.Companies.Queries.GetAllCompanies;

public record GetAllCompaniesQuery : IRequest<IDataResponse<List<GetAllCompaniesQueryResponse>>> {}
