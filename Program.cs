var builder = WebApplication.CreateBuilder(args);

// Configura o CORS para permitir todos os acessos (ou ajuste conforme necessário)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// Adiciona os serviços de controladores da API
builder.Services.AddControllers();

var app = builder.Build();

// Ativa o CORS usando a política definida
app.UseCors("AllowAll");

app.MapControllers(); // Mapeia automaticamente os controladores

app.Run();
