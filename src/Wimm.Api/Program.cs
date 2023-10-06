using JetBrains.Annotations;

using Wimm.Api.Categories;
using Wimm.Api.Common.Database;
using Wimm.Api.Common.ErrorHandling;
using Wimm.Api.Common.SystemClock;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSystemClock();

builder.Services.AddDatabase(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDatabase();

app.UseHttpsRedirection();

#pragma warning disable S125
//app.UseAuthorization();
#pragma warning restore S125

app.UseErrorHandling();

app.MapCategories();

app.Run();

#pragma warning disable 1591
namespace Wimm.Api
{
    [UsedImplicitly]
    public sealed class Program
    {
    }
}
#pragma warning restore 1591