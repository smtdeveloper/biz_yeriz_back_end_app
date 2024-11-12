using AutoMapper;
using bizyeriz.Application.Features.Companies.Commands.AddCompany;
using bizyeriz.Application.Features.Companies.Commands.DeleteCompany;
using bizyeriz.Application.Features.Companies.Commands.UpdateCompany;
using bizyeriz.Application.Features.Companies.Queries.GetAllCompanies;
using bizyeriz.Application.Features.Companies.Queries.GetCompanyById;
using bizyeriz.Application.Features.Companies.Queries.GetNearbyCompanies;
using bizYeriz.Domain.Entities.CompanyEntities;

namespace bizyeriz.Application.Features.Companies.Profiles;

public class CompanyMappings : Profile
{
    public CompanyMappings()
    {
        CreateMap<AddCompanyQuery, Company>();
        CreateMap<Company, GetCompanyByIdQueryResponse>().ReverseMap();
        CreateMap<Company, GetAllCompaniesQueryResponse>().ReverseMap();
        CreateMap<Company, AddCompanyQueryResponse>().ReverseMap();
        CreateMap<Company, DeleteCompanyQueryResponse>().ReverseMap();
        CreateMap<Company, DeleteCompanyQuery>().ReverseMap();
        CreateMap<Company, UpdateCompanyQueryResponse>().ReverseMap();
        CreateMap<Company, UpdateCompanyQuery>().ReverseMap();        
        CreateMap<Company, GetNearbyCompaniesQueryResponse>().ReverseMap();        
    }
}
