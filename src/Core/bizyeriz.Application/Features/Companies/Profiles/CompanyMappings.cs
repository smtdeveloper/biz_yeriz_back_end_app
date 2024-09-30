using AutoMapper;
using bizyeriz.Application.Features.Companies.Commands.AddCompany;
using bizyeriz.Application.Features.Companies.Commands.DeleteCompany;
using bizyeriz.Application.Features.Companies.Queries.GetAllCompanies;
using bizyeriz.Application.Features.Companies.Queries.GetCompanyById;
using bizYeriz.Domain.Entities.CompanyEntities;

namespace bizyeriz.Application.Features.Companies.Profiles;

public class CompanyMappings : Profile
{
    public CompanyMappings()
    {

        CreateMap<AddCompanyQuery, Company>()
     .ForMember(dest => dest.Neighborhood, opt => opt.Ignore())
     .ForMember(dest => dest.CompanyUsers, opt => opt.Ignore())
     .ForMember(dest => dest.Foods, opt => opt.Ignore())
     .ForMember(dest => dest.CuisineCategories, opt => opt.Ignore())
     .ForMember(dest => dest.WorkingHours, opt => opt.Ignore())
     .ForMember(dest => dest.Orders, opt => opt.Ignore())
     .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));  // Map non-null properties only

        CreateMap<Company, GetCompanyByIdQueryResponse>().ReverseMap();
        CreateMap<Company, GetAllCompaniesQueryResponse>().ReverseMap();
        CreateMap<Company, AddCompanyQueryResponse>().ReverseMap();
        CreateMap<Company, DeleteCompanyQueryResponse>().ReverseMap();
    }
}
