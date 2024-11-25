using Microsoft.OpenApi.Models;
using ProductionOrderSEQUOR.API.Middleware;
using ProductionOrderSEQUOR.Infra.Ioc;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructureSwagger();


//builder.Services.AddSwaggerGen();

// Chamar AddInfrastructure com o par�metro de configura��o
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure o pipeline de requisi��es HTTP
if (app.Environment.IsDevelopment()) // TIRAR OU COLOCAR INVERS�O QUANDO FOR USAR NA PRODU��O < - (!)
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication(); // VERIFICAR AUTENTICA��O
app.UseAuthorization(); // USU�RIO AUTENTICADO



app.MapControllers();
app.Run();
