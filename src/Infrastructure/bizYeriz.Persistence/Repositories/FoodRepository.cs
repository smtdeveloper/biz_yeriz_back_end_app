using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.FoodEntities;

namespace bizYeriz.Persistence.Repositories;

public class FoodRepository : AsyncGenericRepository<Food, Guid>, IFoodRepository
{
    public FoodRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
