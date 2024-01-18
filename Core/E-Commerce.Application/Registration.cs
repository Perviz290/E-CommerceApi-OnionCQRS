using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace E_Commerce.Application
{
    public static class Registration
    {
        // IMediator Dependency Injection
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly=Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(assembly));



        }
        



    }
}
