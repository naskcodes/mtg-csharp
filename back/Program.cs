using Microsoft.EntityFrameworkCore;
using mtg.Api.Data;
using Npgsql;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var bdConnection = new NpgsqlDataSourceBuilder(builder.Configuration.GetConnectionString("mtgpostgres"));

bdConnection.EnableDynamicJson(); // Enable dynamic JSON serialization

var dataSource = bdConnection.Build();

builder.Services.AddDbContext<MTGContext>(options => options.UseNpgsql(dataSource));

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();


if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.Run();