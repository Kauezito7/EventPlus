using Event_plus.Repositories;
using Event_plus.Context;
using Event_plus.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services // Acessa a cole��o de servi�os da aplica��o (Dependency Injection)
    .AddControllers() // Adiciona suporte a controladores na API (MVC ou Web API)
    .AddJsonOptions(options => // Configura as op��es do serializador JSON padr�o (System.Text.Json)
    {
        // Configura��o para ignorar propriedades nulas ao serializar objetos em JSON
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;

        // Configura��o para evitar refer�ncia circular ao serializar objetos que possuem relacionamentos recursivos
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });



// Adiciona o contexto do banco de dados (exemplo com SQL Server)
builder.Services.AddDbContext<Evento_Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<ITipoEventoRepository, TipoEventoRepository>();
//builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
//builder.Services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();
//builder.Services.AddScoped<IPresencaEventosRepository, PresencaEventosRepository>();
//builder.Services.AddScoped<IComentarioEventoRepository, ComentarioEventoRepository>();


builder.Services.AddControllers();

var app = builder.Build();



app.MapControllers();
app.Run();