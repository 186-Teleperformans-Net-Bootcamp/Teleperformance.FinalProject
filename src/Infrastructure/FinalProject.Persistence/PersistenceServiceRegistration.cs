using FinalProject.Application.Interfaces.Repositories.CategoryRepositories;
using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using FinalProject.Domain.Entities.Identity;
using FinalProject.Persistence.Contexts;
using FinalProject.Persistence.Repositories.CategoryRepositories;
using FinalProject.Persistence.Repositories.ProductRepositories;
using FinalProject.Persistence.Repositories.ShopListRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProject.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<MsSqlDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("MsSqlConnection")));
            //services.AddIdentity<AppUser, AppRole>(options =>
            //{
            //    options.Password.RequiredLength = 3;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireDigit = false;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireUppercase = false;
            //}).AddEntityFrameworkStores<MsSqlDbContext>();

            services.AddDbContext<PostgreSqlDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PosgreSqlConnection")));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<PostgreSqlDbContext>();

            services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
            services.AddScoped<IShopListCommandRepository, ShopListCommandRepository>();
            services.AddScoped<IShopListQueryRepository, ShopListQueryRepository>();
            services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
            services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
        }
    }
}
