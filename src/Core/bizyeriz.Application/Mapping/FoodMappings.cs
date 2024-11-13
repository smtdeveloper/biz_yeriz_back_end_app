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
        CreateMap<AddFoodCommand, Food>();
        CreateMap<Food, GetFoodByIdQueryResponse>().ReverseMap();       
        CreateMap<Food, GetAllFoodsQueryResponse>().ReverseMap();       
        CreateMap<Food, AddFoodCommandResponse>().ReverseMap();
        CreateMap<Food, DeleteFoodCommandResponse>().ReverseMap();
        CreateMap<Food, DeleteFoodCommand>().ReverseMap();
        CreateMap<Food, UpdateFoodCommandResponse>().ReverseMap();
        CreateMap<Food, UpdateFoodCommand>().ReverseMap();
    }
}