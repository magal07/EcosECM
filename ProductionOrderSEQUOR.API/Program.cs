using Microsoft.OpenApi.Models;
using ProductionOrderSEQUOR.API.Middleware;
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
if (app.Environment.IsDevelopment()) // TIRAR OU COLOCAR INVERSÃO QUANDO FOR USAR NA PRODUÇÃO < - (!)
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication(); // VERIFICAR AUTENTICAÇÃO
app.UseAuthorization(); // USUÁRIO AUTENTICADO



app.MapControllers();
app.Run();
