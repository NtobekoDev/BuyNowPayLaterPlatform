using BNPLService.Data;
using BNPLService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BNPLDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("BNPLDbConnection")));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHttpClient();
builder.Services.AddScoped<BNPLManager>(s => 
{ var httpClientFactory = s.GetRequiredService<IHttpClientFactory>();
    return new BNPLManager(httpClientFactory.CreateClient());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
