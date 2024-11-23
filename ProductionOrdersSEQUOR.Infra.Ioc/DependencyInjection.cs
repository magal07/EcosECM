using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProductionOrderSEQUOR.Application.Interfaces;
using ProductionOrderSEQUOR.Application.Mappings;
using ProductionOrderSEQUOR.Application.Services;
using ProductionOrderSEQUOR.Domain.Account;
using ProductionOrderSEQUOR.Domain.Interfaces;
using ProductionOrderSEQUOR.Infra.Data.Context;
using ProductionOrderSEQUOR.Infra.Data.Identity;
using ProductionOrderSEQUOR.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true, // validar qm gera o token
                    ValidateAudience = true, // valida o destinatário
                    ValidateLifetime = true, // tempo p/ o token ser validado
                    ValidateIssuerSigningKey = true, // valida o login

                    ValidIssuer = configuration["jwt:issuer"],
                    ValidAudience = configuration["jwt:audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["jwt:secretKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            // REPOSITORIES

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // SERVICES

            services.AddScoped<IUserService, UserService>(); // cliente
            services.AddScoped<IUsuarioService, UsuarioService>(); // usuário

            // AUTHENTICATION

            services.AddScoped<IAuthenticate, AuthenticateService>();

            return services;
        }
    }

}