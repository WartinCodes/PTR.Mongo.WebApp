using Microsoft.EntityFrameworkCore;
using PTR.Mongo.WebApp.Entities;

namespace PTR.Mongo.WebApp.Data;

public class RestaurantApiContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public RestaurantApiContext(DbContextOptions<RestaurantApiContext> options) : base(options)
    {

    }


}