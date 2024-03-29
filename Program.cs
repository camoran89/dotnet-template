using cd_plantilla_backend.Interfaces;
using cd_plantilla_backend.Models;
using cd_plantilla_backend.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ConnectionStrings>(
    builder.Configuration.GetSection(nameof(ConnectionStrings)));

builder.Services.AddSingleton<IConnectionStrings>(sp => 
    sp.GetRequiredService<IOptions<ConnectionStrings>>().Value);

builder.Services.AddSingleton<IMongoClient>(sp => 
    new MongoClient(builder.Configuration.GetValue<string>("ConnectionStrings:Server")));

builder.Services.AddScoped<ITemplateService, TemplateService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
