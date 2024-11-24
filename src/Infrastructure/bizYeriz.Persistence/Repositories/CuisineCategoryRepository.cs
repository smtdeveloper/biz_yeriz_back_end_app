using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.FoodEntities;

namespace bizYeriz.Persistence.Repositories;

public class CuisineCategoryRepository : AsyncGenericRepository<CuisineCategory, int>, ICuisineCategoryRepository
{
    public CuisineCategoryRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}