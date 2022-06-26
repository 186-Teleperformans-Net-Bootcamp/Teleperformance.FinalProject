using FinalProject.Application.Interfaces.Services;
using FinalProject.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Text;

namespace FinalProject.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IGenerateToken, GenerateToken>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateAudience = false, //Oluşturulacak token değerini kimlerin/hangi originlerin/sitelerin kullanıcı belirlediğimiz değerdir. -> www.bilmemne.com
                        ValidateIssuer = false, //Oluşturulacak token değerini kimin dağıttını ifade edeceğimiz alandır. -> www.myapi.com
                        ValidateLifetime = true, //Oluşturulan token değerinin süresini kontrol edecek olan doğrulamadır.
                        ValidateIssuerSigningKey = true, //Üretilecek token değerinin uygulamamıza ait bir değer olduğunu ifade eden suciry key verisinin doğrulanmasıdır.

                        //  ValidAudience = configuration["Token:Audience"],
                        //ValidIssuer = configuration["Token:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]))
                    };
                });
            //.AddJwtBearer("User", options =>
            // {
            //     options.TokenValidationParameters = new()
            //     {
            //         ValidateAudience = true, //Oluşturulacak token değerini kimlerin/hangi originlerin/sitelerinkullanıcı      belirlediğimiz değerdir. -> www.bilmemne.com
            //         ValidateIssuer = true, //Oluşturulacak token değerini kimin dağıttını ifade edeceğimiz alandır. ->   www.myapi.com
            //         ValidateLifetime = true, //Oluşturulan token değerinin süresini kontrol edecek olan doğrulamadır.
            //         ValidateIssuerSigningKey = true, //Üretilecek token değerinin uygulamamıza ait bir değer olduğunu ifade eden   suciry key verisinin doğrulanmasıdır.

            //         ValidAudience = configuration["Token:Audience"],
            //         ValidIssuer = configuration["Token:Issuer"],
            //         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]))
            //     };
            // });

        }

    }
}
