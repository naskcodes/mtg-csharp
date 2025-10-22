using Microsoft.EntityFrameworkCore;
using mtg.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MTGContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("mtgpostgres")));

// Add services to the container.
builder.Services.AddControllers();

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