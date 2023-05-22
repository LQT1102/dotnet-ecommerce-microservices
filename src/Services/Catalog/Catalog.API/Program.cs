using Catalog.API.Data;
using Catalog.API.Repositories;
using Catalog.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Khai b�o IDBContext
builder.Services.AddSingleton<IDBContext, DBContext>();

// Khai b�o IProductRepository
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

// Khai b�o c�c service
builder.Services.AddSingleton<IProductService, ProductService>();

// Injection

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
