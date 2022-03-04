using DemoABC.EntityFramework;
using DemoABC.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoABC.Services
{
    public static class EntityService
    {
        private const string _defaultConnection = "DefaultConnection";

        public static void AddDbContextRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(_defaultConnection)))
                .AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }
    }
}
