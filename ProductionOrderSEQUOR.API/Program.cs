using Microsoft.OpenApi.Models;
using ProductionOrderSEQUOR.Infra.Ioc;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructureSwagger();


//builder.Services.AddSwaggerGen();

// Chamar AddInfrastructure com o parâmetro de configuração
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
