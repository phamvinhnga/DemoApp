using DemoABC.Base;
using DemoABC.Base.interfaces;
using DemoABC.Business.Managers;
using DemoABC.EntityFramework.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoABC.Services
{
    public static class ManagerService
    {
        public static void AddManagerRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<TokenManager>(); 
            services.AddTransient<RegiterManager>(); 

            services.AddTransient<IRepository<Organization>, Repository<Organization>>(); 
            services.AddTransient<IRepository<UserOrganization>, Repository<UserOrganization>>(); 
            services.AddTransient<IRepository<Title>, Repository<Title>>(); 
        }
    }
}
