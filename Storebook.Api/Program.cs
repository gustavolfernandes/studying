using Microsoft.EntityFrameworkCore;
using Storebook;
using Storebook.Domain.Interfaces.Repositories;
using Storebook.Domain.Interfaces.UnitOfWork;
using Storebook.Infra;
using Storebook.Infra.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;
builder.Services.AddDbContext<StorebookContext>(options =>
{
    var cs = configuration.GetConnectionString("Database");

    options.UseSqlServer(cs!, x =>
    {
        x.MigrationsAssembly("Storebook.Infra");
    });
});
builder.Services.AddScoped<ILivrosRepository, LivrosRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<StorebookContext>();
context.Database.Migrate();

app.MapEndpoints();
app.UseHttpsRedirection();
app.Run();