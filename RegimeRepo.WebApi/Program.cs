using Microsoft.EntityFrameworkCore;
using RegimeRepo.WebApi.ApplicationDbContext;
using RegimeRepo.WebApi.Businnes.Abstract;
using RegimeRepo.WebApi.Businnes.Concrete;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IApplicationBuilder, ApplicationBuilder>();
builder.Services.AddDbContext<hakanhak_HakanHakyemezContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("hakyemezConStr")));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRegimeService, RegimeService>();


var configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder
            .AllowAnyOrigin() // İzin verilen kökenleri buraya ekleyin
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
var app = builder.Build();
app.UseCors("AllowSpecificOrigin");

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
