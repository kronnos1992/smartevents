using gesteventos.Application.Services.Implementations;
using gesteventos.Application.Services.Interfaces;
using gesteventos.Persistence.Database;
using gesteventos.Persistence.Implementations;
using gesteventos.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(
        x =>
            x.SerializerSettings.ReferenceLoopHandling
            =
            Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();


builder.Services.AddDbContext<GestEvetosDbContext>(op =>
   op.UseSqlite(configuration.GetConnectionString("default"))
   .EnableDetailedErrors()
);

//injecção de dependecia
builder.Services.AddScoped<IPersistenceContract, PersistenceImplemetations>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IEventoPersistenceContract, EventoPersistenceImplementation>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(p =>
{
    p.AllowAnyHeader()
     .WithOrigins("http://localhost:4200")
     .AllowCredentials();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
