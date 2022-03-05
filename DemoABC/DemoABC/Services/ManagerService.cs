using DemoABC.Base;
using DemoABC.Base.interfaces;
using DemoABC.Business.Managers;
using DemoABC.EntityFramework.Entities;
using DemoABC.Middlewares;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DemoABC.Services
{
    public static class ManagerService
    {
        public static void AddManagerRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ExceptionHandlerMiddleware>();

            services.AddTransient<TokenManager>(); 
            services.AddTransient<RegiterManager>(); 

            services.AddTransient<IRepository<Organization, Guid>, Repository<Organization, Guid>>(); 
            services.AddTransient<IRepository<UserOrganization, Guid>, Repository<UserOrganization, Guid>>(); 
            services.AddTransient<IRepository<Title, Guid>, Repository<Title, Guid>>(); 
        }
    }
}
