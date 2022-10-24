using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectManagement.Persistence.Contexts;
using System.Text;

namespace ProjectManagement.WebAPI.PresentationExtensions
{
    public static class PresentationCustomExtension
    {
        public static void AddPresentationExtension(this IServiceCollection services, IConfiguration configuration)
        {

            // DbContext conf.
            services.AddDbContext<ProjectManagementDbContext>(options =>
            {
                options.UseSqlite(configuration["ConnectionStrings:SqliteConnection"]);
                options.UseLazyLoadingProxies();

            });


            // JWT Authentication conf.
            services.AddAuthentication(conf =>
            {
                conf.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                conf.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new()
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        RequireExpirationTime = true,

                        ValidAudience = configuration.GetValue<string>("Jwt:Audience"),
                        ValidIssuer = configuration.GetValue<string>("Jwt:Issuer"),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                       // LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.Now : false
                    };

                });

            // Fluent Validation conf.
            services.AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<Program>();
                opt.DisableDataAnnotationsValidation = false;
            });

        }
    }
}
