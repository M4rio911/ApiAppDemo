using ApiAppDemo.Application;
using ApiAppDemo.Persistance;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment;
var rootPath = env.ContentRootPath;
var commonFolder = Path.Combine(rootPath, "config");
var path = Path.Combine(commonFolder, "appsettings.json");

builder.Configuration
    .AddJsonFile(path, optional: true, reloadOnChange: false)
    .AddJsonFile("/appsettings.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

//SWAGGER
builder.Services.AddSwaggerGen();

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .SetIsOriginAllowed(_ => true);
    });
});

//MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationReferenceAssembly).Assembly));

//DB
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")
   ));

//APP
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
