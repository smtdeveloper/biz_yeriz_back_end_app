using AutoMapper;
using bizyeriz.Application.Features.Companies.Queries.GetAllFilters;
using bizyeriz.Application.Features.CuisineCategories.Queries.GetAllCuisineCategories;
using bizYeriz.Domain.Entities.FoodEntities;

namespace bizyeriz.Application.Features.CuisineCategories.Profiles;

public class CuisineCategoryMappings : Profile
{
    public CuisineCategoryMappings()
    {
        CreateMap<GetAllCuisineCategoriesQueryResponse, CuisineCategory>().ReverseMap();
        CreateMap<GetAllCuisineCategoriesQuery, CuisineCategory>().ReverseMap();
        CreateMap<CuisineCategory, CuisineCategoryDto>().ReverseMap();
    }
}