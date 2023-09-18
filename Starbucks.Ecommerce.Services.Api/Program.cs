using Starbucks.Ecommerce.Application.Interface;
using Starbucks.Ecommerce.Application.Main;
using Starbucks.Ecommerce.Domain.Core;
using Starbucks.Ecommerce.Domain.Entity;
using Starbucks.Ecommerce.Domain.Interface;
using Starbucks.Ecommerce.Infraestructure.Data;
using Starbucks.Ecommerce.Infraestructure.Interface;
using Starbucks.Ecommerce.Infraestructure.Repository;
using Starbucks.Ecommerce.Transversal.Common;
using Starbucks.Ecommerce.Transversal.Logging;
using Starbucks.Ecommerce.Transversal.Mapper;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingsProfile));

builder.Services.AddDbContext<StarbucksDatabaseContext>();

builder.Services.AddScoped<IUserApplication, UserApplication>();
builder.Services.AddScoped<IRoleApplication, RoleApplication>();
builder.Services.AddScoped<IProvinceApplication, ProvinceApplication>();
builder.Services.AddScoped<IProductApplication, ProductApplication>();
builder.Services.AddScoped<IIngredientApplication, IngredientApplication>();
builder.Services.AddScoped<IOrderApplication, OrderApplication>();

builder.Services.AddScoped<IUserDomain, UserDomain>();
builder.Services.AddScoped<IProductDomain, ProductDomain>();
builder.Services.AddScoped<IOrderDomain, OrderDomain>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IProvinceRepository, ProvinceRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", builder =>
    {
        builder
            .AllowAnyOrigin() 
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<StarbucksDatabaseContext>();
    DbInitializer.Initialize(dbContext);
}

app.UseCors("MyCorsPolicy");
app.UseAuthorization();
app.MapControllers();
app.Run();