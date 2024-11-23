using bizyeriz.Application.Features.Companies.Queries.GetAllCompanies;

namespace bizyeriz.Application.Features.Companies.Queries.Filter;

public class GetCompaniesFilterQueryHandler : IRequestHandler<GetCompaniesFilterQuery, List<GetCompaniesFilterQueryResponse>>
{

    public GetCompaniesFilterQueryHandler()
    {
        
    }

    public Task<List<GetCompaniesFilterQueryResponse>> Handle(GetCompaniesFilterQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}