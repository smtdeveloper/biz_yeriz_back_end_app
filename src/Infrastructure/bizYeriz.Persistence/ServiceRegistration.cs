using bizyeriz.Application.Features.Companies.BusinessRules;
using bizyeriz.Application.Features.Foods.BusinessRules;
using bizyeriz.Application.Interfaces.Repositories;
using bizyeriz.Application.Interfaces.UnitOfWork;
using bizYeriz.Persistence.Repositories;


namespace bizYeriz.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            // Register AppDbContext using Npgsql (PostgreSQL)
            services.AddDbContext<AppDbContext>(opt =>
                opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // Register repositories and unit of work
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped(typeof(IAsyncGenericRepository<,>), typeof(AsyncGenericRepository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Register business rules
            services.AddScoped<CompanyBusinessRules>();
            services.AddTransient<FoodBusinessRules>();


            // Register AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}