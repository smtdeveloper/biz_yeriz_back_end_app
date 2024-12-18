using bizYeriz.Shared.Responses;

namespace bizyeriz.Application.Features.Companies.Commands.DeleteCompany;

public record DeleteCompanyCommand(Guid Id) : IRequest<IResponse>;

