using PTR.Mongo.WebApp.Data;
using PTR.Mongo.WebApp.Models.Dtos.Requests;
using PTR.Mongo.WebApp.Models.Validators;
using PTR.Mongo.WebApp.Repositories.Implementations;
using PTR.Mongo.WebApp.Repositories.Interfaces;
using PTR.Mongo.WebApp.Services.Implementations;
using PTR.Mongo.WebApp.Services.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace PTR.Mongo.WebApp.Entities.Extensions
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<RestaurantApiContext>(options => options.UseSqlServer(configuration.GetConnectionString("RestaurantAPI")));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();

            services.AddScoped<IValidator<CreateProductRequestDto>, CreateProductRequestDtoValidator>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}