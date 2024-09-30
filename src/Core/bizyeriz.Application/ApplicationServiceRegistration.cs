using bizyeriz.Application.Features.Companies.Profiles;
using bizyeriz.Application.Interfaces.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace bizyeriz.Application;

public static class ApplicationServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services) 
    {
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());            
        });
       
    }
}
