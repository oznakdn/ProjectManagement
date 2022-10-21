using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ProjectManagement.Application.Extensions
{
    public static class ApplicationCustomExtension
    {
        public static void AddApplicationExtension(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationCustomExtension));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
