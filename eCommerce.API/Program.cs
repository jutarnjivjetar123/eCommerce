using eCommerce.Services;
using eCommerce.Services.Database;
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

builder.Services.AddTransient<IProductsService, ProductsService>();

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
