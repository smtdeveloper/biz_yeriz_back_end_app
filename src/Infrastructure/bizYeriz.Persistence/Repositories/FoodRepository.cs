using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.FoodEntities;

namespace bizYeriz.Persistence.Repositories;

public class FoodRepository : AsyncGenericRepository<Food, int>, IFoodRepository
{
    public FoodRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
