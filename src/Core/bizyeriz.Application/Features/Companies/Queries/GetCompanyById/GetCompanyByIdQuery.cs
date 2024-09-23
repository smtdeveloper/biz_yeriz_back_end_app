using MediatR;

namespace bizyeriz.Application.Features.Companies.Queries.GetCompanyById;

public record GetCompanyByIdQuery(Guid Id) : IRequest<GetCompanyByIdQueryResponse>;