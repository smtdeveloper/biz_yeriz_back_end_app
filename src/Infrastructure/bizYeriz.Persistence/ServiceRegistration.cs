using bizyeriz.Application.Features.Companies.BusinessRules;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Persistence.Repositories;

namespace bizYeriz.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<CompanyBusinessRules>();

        }
    }
}