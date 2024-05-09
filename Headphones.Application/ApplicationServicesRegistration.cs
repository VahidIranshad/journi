using FluentValidation;
using Headphones.Application.Behaviors;
using Headphones.Application.Dtos.HeadphonesDtos;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Headphones.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                config.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });

            services.AddTransient<IValidator<HeadphoneCrudDto>, HeadphoneCrudDtoValidation>();

            return services;
        }
    }
}
