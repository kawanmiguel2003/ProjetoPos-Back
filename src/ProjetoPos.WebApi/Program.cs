using Microsoft.EntityFrameworkCore;
using ProjetoPos.Domain.Interfaces.Repositories;
using ProjetoPos.Domain.Interfaces.Services;
using ProjetoPos.Domain.Services;
using ProjetoPos.Infra.Data.Context;
using ProjetoPos.Infra.Data.Repositories;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using ProjetoPos.Domain.DTOs.ProfessorDto.Adicionar;
using ProjetoPos.Domain.DTOs.ProfessorDto.Atualizar;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IServiceProfessor, ServiceProfessor>();
builder.Services.AddScoped<IRepositoryProfessor, RepositoryProfessor>();

builder.Services.AddDbContext<ProjetoPosContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ProjetoPosConnection"));
});

builder.Services.AddCors();

builder.Services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters
        .Add(new JsonStringEnumConverter()));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(cors => cors
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapPost("/professor/adicionar", ([FromServices] IServiceProfessor serviceProfessor, ProfessorAdicionarDto professorAdicionarDto) =>
{
    var response = serviceProfessor.Adicionar(professorAdicionarDto);
    return response.Sucesso ? Results.Created("created", response) : Results.BadRequest(response);
})
.WithTags("Professor");

app.MapGet("/professor/listar", ([FromServices] IServiceProfessor serviceProfessor) =>
{
    var response = serviceProfessor.Listar();
    return Results.Ok(response);
})
.WithTags("Professor");

app.MapGet("/professor/obter/{id:guid}", ([FromServices] IServiceProfessor serviceProfessor, Guid id) =>
{
    var response = serviceProfessor.Obter(id);
    return response.Sucesso ? Results.Ok(response) : Results.BadRequest(response);
})
.WithTags("Professor");

app.MapPut("/professor/atualizar", ([FromServices] IServiceProfessor serviceProfessor, ProfessorAtualizarDto professorAtualizarDto) =>
{
    var response = serviceProfessor.Atualizar(professorAtualizarDto);
    return response.Sucesso ? Results.Ok(response) : Results.BadRequest(response);
})
.WithTags("Professor");

app.MapDelete("/professor/remover/{id:guid}", ([FromServices] IServiceProfessor serviceProfessor, Guid id) =>
{
    var response = serviceProfessor.Remover(id);
    return response.Sucesso ? Results.Ok(response) : Results.BadRequest(response);
})
.WithTags("Professor");

app.UseHttpsRedirection();

app.Run();
