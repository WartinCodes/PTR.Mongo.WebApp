using PTR.Mongo.WebApp.Data;
using PTR.Mongo.WebApp.Entities.Extensions;

var builder = WebApplication.CreateBuilder(args);

const string AllowAllPolicy = "AllowAll";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services
    .AddDatabase(builder.Configuration)
    .AddMongoDatabase(builder.Configuration)
    .AddRepositories()
    .AddServices()
    .AddValidators()
    .AddJwtAuthentication(builder.Configuration)
    .AddSwaggerWithJwt();

builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowAllPolicy, policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web App v1");
        c.RoutePrefix = string.Empty;
    });
//}

app.UseHttpsRedirection();

app.UseCors(AllowAllPolicy);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();