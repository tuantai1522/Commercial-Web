using Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            //Add mediar into my project
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //Working with cookies
            services.AddHttpContextAccessor();

            //working with JWT
            services.AddScoped<TokenService>();
        }
    }
}
