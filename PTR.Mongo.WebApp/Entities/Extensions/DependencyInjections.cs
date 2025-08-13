using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PTR.Mongo.WebApp.Data;
using PTR.Mongo.WebApp.Models.Dtos.Requests;
using PTR.Mongo.WebApp.Models.Security;
using PTR.Mongo.WebApp.Models.Validators;
using PTR.Mongo.WebApp.NoSQLRepositories.Implementations;
using PTR.Mongo.WebApp.NoSQLRepositories.Interfaces;
using PTR.Mongo.WebApp.Repositories.Implementations;
using PTR.Mongo.WebApp.Repositories.Interfaces;
using PTR.Mongo.WebApp.Services.Implementations;
using PTR.Mongo.WebApp.Services.Interfaces;

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

        public static IServiceCollection AddMongoDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<MongoDbConfiguration>(options =>
            {
                options.ConnectionString = configuration["MongoDbSettings:ConnectionString"];
                options.Database = configuration["MongoDbSettings:DatabaseName"];
            });

            services.AddSingleton<MongoDbContext>();
            services.AddSingleton<MongoDbInitializer>();

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var initializer = scope.ServiceProvider.GetRequiredService<MongoDbInitializer>();
                initializer.Initialize();
            }

            return services;
        }


        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();

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
            services.AddScoped<IReviewService, ReviewService>();

            return services;
        }
    }
}