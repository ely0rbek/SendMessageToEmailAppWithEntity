using EmailSenderApp.Infrastructure.Repositories.CheckUserRepositories;
using EmailSenderApp.Infrastructure.Repositories.LoginRepositories;
using EmailSenderApp.Infrastructure.Repositories.RegisterRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("ConnectPostgres")));
            
            services.AddScoped<IRegisterRepository, RegisterRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ICheckUserRepository, CheckUserRepository>();

            return services;
        }
    }
}
