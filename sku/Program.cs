using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using sku.Core.Database;
using sku.Core.Mapper.Builder;
using sku.Core.Repositories;
using sku.Core.Repositories.Contracts;
using sku.Core.Services;
using sku.Core.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection")));

// Automapper
builder.Services.AddSingleton(factory => MapperBuilder.Mapper);
builder.Services.AddSingleton(factory => MapperBuilder.Configuration);

builder.Services.AddScoped<ISkuService, SkuService>();
builder.Services.AddScoped<ISkuRepository, SkuRepository>();


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

