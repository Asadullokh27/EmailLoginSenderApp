using EmailSenderApp.Application.Services.LoginServices;
using EmailSenderApp.Application.Services.RegistrationServices;
using EmailSenderApp.Application.Services.ValidationServices;
using Microsoft.Extensions.DependencyInjection;

namespace EmailSenderApp.Application
{
    public static class ApplicationDependencyInjection
    {

        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            return services;
        }

    }
}
