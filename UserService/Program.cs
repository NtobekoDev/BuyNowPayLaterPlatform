using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using UserService.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<UserDbContext>( options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("UserDbConnection")) );
    
// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<UserService.Services.UserService>(); 


// Add Swagger support
builder.Services.AddOpenApi();



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
