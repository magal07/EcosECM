using ProductionOrderSEQUOR.API.Models; 
using Microsoft.EntityFrameworkCore;
using ProductionOrderSEQUOR.API.Interfaces;
using ProductionOrderSEQUOR.API.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ProductionOrderSEQUOR.API.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ControleProductionOrderContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*
builder.services.AddScoped<ITokenService,TokenService>();
builder.services.AddAuthentication(JwtBearerDefaults.AuthenticatationScheme);   */

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddAutoMapper(typeof(EntitiesToDTOMappingProfile));

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
