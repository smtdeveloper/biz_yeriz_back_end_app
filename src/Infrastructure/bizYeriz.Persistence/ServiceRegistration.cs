using bizyeriz.Application.Features.Auths.BusinessRules;
using bizyeriz.Application.Features.Companies.BusinessRules;
using bizyeriz.Application.Features.Foods.BusinessRules;
using bizyeriz.Application.Interfaces.Repositories;
using bizyeriz.Application.Interfaces.UnitOfWork;
using bizyeriz.Application.Services.AuthService;
using bizYeriz.Persistence.Repositories;
using bizYeriz.Shared.Security.JWT;

namespace bizYeriz.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
    {
        // Register AppDbContext using Npgsql (PostgreSQL)
        services.AddDbContext<AppDbContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), o => o.UseNetTopologySuite()));

        // Register repositories and unit of work
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<ICuisineCategoryRepository, CuisineCategoryRepository>();
        services.AddScoped<IFoodRepository, FoodRepository>();
        services.AddScoped(typeof(IAsyncGenericRepository<,>), typeof(AsyncGenericRepository<,>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<ITokenHelper, JwtHelper>();



        // Register business rules
        services.AddScoped<CompanyBusinessRules>();
        services.AddScoped<FoodBusinessRules>();
        services.AddScoped<AuthBusinessRules>();

        // Register AutoMapper
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    }
}