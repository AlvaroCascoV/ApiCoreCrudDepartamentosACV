using ApiCoreCrudDepartamentosACV.Data;
using ApiCoreCrudDepartamentosACV.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("AZURETAJAMAR");
builder.Services.AddTransient<RepositoryDepartamentos>();
builder.Services.AddDbContext<DepartamentosContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();


app.MapOpenApi();
app.MapScalarApiReference();

app.MapGet("/", context =>
{
    context.Response.Redirect("/scalar");
    return Task.CompletedTask;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
