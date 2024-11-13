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
        CreateMap<AddCompanyCommand, Company>();
        CreateMap<Company, GetCompanyByIdQueryResponse>().ReverseMap();
        CreateMap<Company, GetAllCompaniesQueryResponse>().ReverseMap();
        CreateMap<Company, AddCompanyCommandResponse>().ReverseMap();
        CreateMap<Company, DeleteCompanyCommandResponse>().ReverseMap();
        CreateMap<Company, DeleteCompanyCommand>().ReverseMap();
        CreateMap<Company, UpdateCompanyCommandResponse>().ReverseMap();
        CreateMap<Company, UpdateCompanyCommand>().ReverseMap();        
        CreateMap<Company, GetNearbyCompaniesQueryResponse>().ReverseMap();

        CreateMap<Company, GetNearbyCompaniesQueryResponse>()
            .ForMember(dest => dest.Lat, opt => opt.MapFrom(src => src.Location != null ? src.Location.X : (double?)null))
            .ForMember(dest => dest.Long, opt => opt.MapFrom(src => src.Location != null ? src.Location.Y : (double?)null))
            .ReverseMap();

    }
}
