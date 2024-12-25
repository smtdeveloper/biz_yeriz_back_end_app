using bizYeriz.Domain.Entities.AuthEntities;

namespace bizyeriz.Application.Interfaces.Repositories;

public interface IUserRepository :  IAsyncGenericRepository<User, Guid>
{
    Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<User?> GetUserByGsmAsync(string gsm, CancellationToken cancellationToken = default);
}