using JetBrains.Annotations;
using Wimm.Api.Categories;
using Wimm.Api.Common.Clock;
using Wimm.Api.Common.Database;
using Wimm.Api.Common.ErrorHandling;
using Wimm.Api.Common.Events.EventBus;
using Wimm.Api.Transactions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddExceptionHandling();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEventBus();
builder.Services.AddClock();

builder.Services.AddTransactions(builder.Configuration);

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

//app.UseErrorHandling();

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