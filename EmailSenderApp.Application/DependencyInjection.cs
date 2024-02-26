using EmailSenderApp.Application.Services.CheckEmailCodeServices;
using EmailSenderApp.Application.Services.LoginServices;
using EmailSenderApp.Application.Services.RegisterServices;
using EmailSenderApp.Infrastructure.Repositories.RegisterRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace EmailSenderApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ICheckService, CheckService>();
            return services;
        }
    }
}
