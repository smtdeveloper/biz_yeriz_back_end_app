using bizYeriz.Domain.Entities.FoodEntities;

namespace bizyeriz.Application.Interfaces.Repositories;

public interface IFoodRepository : IAsyncGenericRepository<Food, int>
{
}
