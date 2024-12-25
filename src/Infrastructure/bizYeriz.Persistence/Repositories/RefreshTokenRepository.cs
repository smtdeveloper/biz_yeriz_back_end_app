using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.AuthEntities;

namespace bizYeriz.Persistence.Repositories;

public class RefreshTokenRepository : AsyncGenericRepository<RefreshToken, int>, IRefreshTokenRepository
{
    public RefreshTokenRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}