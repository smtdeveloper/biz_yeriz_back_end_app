using AutoMapper;
using bizyeriz.Application.Features.Companies.Queries.GetCompanyById;
using bizYeriz.Domain.Entities.CompanyEntities;

namespace bizyeriz.Application.Features.Companies.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, GetCompanyByIdQueryResponse>();


    }
}
