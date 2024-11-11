using AutoMapper;
using bizyeriz.Application.Features.Foods.Commands.AddCompany;
using bizyeriz.Application.Features.Foods.Commands.AddFood;
using bizyeriz.Application.Features.Foods.Commands.DeleteFood;
using bizyeriz.Application.Features.Foods.Commands.UpdateFood;
using bizyeriz.Application.Features.Foods.Queries.GetAllFoods;
using bizyeriz.Application.Features.Foods.Queries.GetFoodById;
using bizYeriz.Domain.Entities.FoodEntities;

namespace bizyeriz.Application.Mapping;

public class FoodMappings : Profile
{
    public FoodMappings()
    {
        CreateMap<AddFoodQuery, Food>();
        CreateMap<Food, GetFoodByIdQueryResponse>().ReverseMap();       
        CreateMap<Food, GetAllFoodsQueryResponse>().ReverseMap();       
        CreateMap<Food, AddFoodQueryResponse>().ReverseMap();
        CreateMap<Food, DeleteFoodQueryResponse>().ReverseMap();
        CreateMap<Food, DeleteFoodQuery>().ReverseMap();
        CreateMap<Food, UpdateFoodQueryResponse>().ReverseMap();
        CreateMap<Food, UpdateFoodQuery>().ReverseMap();
    }
}