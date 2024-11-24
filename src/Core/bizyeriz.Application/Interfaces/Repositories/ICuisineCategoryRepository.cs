using bizYeriz.Domain.Entities.CompanyEntities;
using bizYeriz.Domain.Entities.FoodEntities;

namespace bizyeriz.Application.Interfaces.Repositories;

public interface ICuisineCategoryRepository : IAsyncGenericRepository<CuisineCategory, int>
{
}