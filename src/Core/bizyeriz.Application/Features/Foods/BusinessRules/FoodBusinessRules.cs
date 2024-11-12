using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.CompanyEntities;
using bizYeriz.Domain.Entities.FoodEntities;

namespace bizyeriz.Application.Features.Foods.BusinessRules;

public class FoodBusinessRules
{
    private readonly IFoodRepository _foodRepository;

    public FoodBusinessRules(IFoodRepository foodRepository)
    {
        _foodRepository = foodRepository;
    }
    
    public async Task CheckIfFoodIsNull(Food food)
    {
        if (food == null)
        {
            throw new Exception("The Food entity cannot be null.");
        }
    }

    public async Task CheckIfIdIsValid(int id)
    {
        if (id <= 0)
        {
            throw new Exception("Invalid ID.");
        }
    }

}
