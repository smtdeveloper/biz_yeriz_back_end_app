using AutoMapper;
using bizyeriz.Application.Features.Users.AddFavoriteCompany;
using bizYeriz.Domain.Entities.CompanyEntities;

namespace bizyeriz.Application.Features.Users.Profiles;

public class UserMappings : Profile
{
    public UserMappings()
    {
        CreateMap<AddFovoriteCompanyCommand, FavoriteCompany>().ReverseMap();
    }
}