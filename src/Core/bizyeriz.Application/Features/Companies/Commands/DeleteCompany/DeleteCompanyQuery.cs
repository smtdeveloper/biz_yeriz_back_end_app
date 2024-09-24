namespace bizyeriz.Application.Features.Companies.Commands.DeleteCompany;

public record DeleteCompanyQuery(Guid Id) : IRequest<DeleteCompanyQueryResponse>;

