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

    // Entity'nin null olup olmadığını kontrol eden kural    
    public async Task CheckIfFoodIsNull(Food food)
    {
        if (food == null)
        {
            throw new Exception("The Food entity cannot be null.");
        }
    }
}
