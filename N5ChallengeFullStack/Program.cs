using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using N5ChallengeFullStack.Interface;
using N5ChallengeFullStack.Model;
using N5ChallengeFullStack.Repository;
using N5ChallengeFullStack.Service;
using Nest;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.





//var app = builder.Build();

var elasticSettings = builder.Configuration.GetSection("ElasticSearch");
var uri = elasticSettings.GetValue<string>("Uri");
var apiKey = elasticSettings.GetValue<string>("ApiKey");
var defaultIndex = elasticSettings.GetValue<string>("DefaultIndex");

// Configurar el cliente de Elasticsearch
builder.Services.AddSingleton<IElasticClient>(sp =>
{
    var settings = new ConnectionSettings(new Uri(uri))
        .DefaultIndex(defaultIndex)
        .ApiKeyAuthentication(new(apiKey));

    var client = new ElasticClient(settings);
    return client;
});

builder.Services.AddDbContext<DbN5Context>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("N5Context")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("OriginAllowedList", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<Repository<Permission>>();
builder.Services.AddScoped<Repository<PermissionType>>();
builder.Services.AddScoped<PermissionService>();
builder.Services.AddScoped<ElasticSearchService<Permission>>();

builder.Services.AddScoped<ElasticSearchService<PermissionType>>();
builder.Services.AddScoped<PermissionTypeService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "N5Challenge", Version = "v1" });
});

var app = builder.Build();
app.UseCors("OriginAllowedList");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "N5Challenge");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
