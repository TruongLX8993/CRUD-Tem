using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.Application
{
    public static class ApplicationConfig
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            return serviceCollection;
        }
    }
}