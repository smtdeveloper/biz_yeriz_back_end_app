using AutoMapper;
using bizyeriz.Application.Features.Companies.Queries.GetAllCompanies;
using bizyeriz.Application.Features.Companies.Queries.GetCompanyById;
using bizYeriz.Domain.Entities.CompanyEntities;

namespace bizyeriz.Application.Features.Companies.Profiles;

public class CompanyMappings : Profile
{
    public CompanyMappings()
    {
        CreateMap<Company, GetCompanyByIdQueryResponse>().ReverseMap();
        CreateMap<Company, GetAllCompaniesQueryResponse>().ReverseMap();
    }
}
