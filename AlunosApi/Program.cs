using AlunosApi.Services.Aluno;
using AlunosApi.Services.Curso;
using AlunosApi.Services.Disciplina;
using AlunosApi.Services.Professor;
using AlunosApi.Utils;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configuração do MongoDB
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddSingleton<IDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

// Injeção de dependência
builder.Services.AddScoped<AlunoService>();
builder.Services.AddScoped<DisciplinaService>();
builder.Services.AddScoped<CursoService>();
builder.Services.AddScoped<ProfessorService>();

// Swagger
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