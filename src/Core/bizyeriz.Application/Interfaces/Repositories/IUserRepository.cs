using bizyeriz.Application.Features.Users.AddFavoriteCompany;
using bizYeriz.Domain.Entities.AuthEntities;
using bizYeriz.Domain.Entities.CompanyEntities;

namespace bizyeriz.Application.Interfaces.Repositories;

public interface IUserRepository :  IAsyncGenericRepository<User, Guid>
{
    Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<User?> GetUserByGsmAsync(string gsm, CancellationToken cancellationToken = default);
    Task<bool> AddFovoriteCompanyAsync(FavoriteCompany command, CancellationToken cancellationToken = default);
}