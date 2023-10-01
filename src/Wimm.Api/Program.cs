using JetBrains.Annotations;

using Wimm.Api.Common.SystemClock;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSystemClock();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandler();

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