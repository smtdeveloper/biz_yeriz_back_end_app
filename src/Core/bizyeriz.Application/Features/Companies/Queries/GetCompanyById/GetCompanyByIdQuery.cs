using bizYeriz.Shared.Responses;

namespace bizyeriz.Application.Features.Companies.Queries.GetCompanyById;

public record GetCompanyByIdQuery(Guid Id) : IRequest<IDataResponse<GetCompanyByIdQueryResponse>>;