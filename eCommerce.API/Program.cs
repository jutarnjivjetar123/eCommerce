using eCommerce.Services;
using eCommerce.Services.Database;
using eCommerce.Model;
using eCommerce.Model.SearchObjects;
using eCommerce.Services;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Load connection string from config file

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add database
builder.Services.AddDbContext<eCommerceContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddMapster();

builder.Services.AddTransient<IProductsService, ProductsService>();
builder.Services.AddTransient<IService<eCommerce.Model.Products, eCommerce.Model.SearchObjects.ProductsSearchObject>>(provider => provider.GetRequiredService<IProductsService>());
builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<IProductCategoriesService, ProductCategoriesService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
