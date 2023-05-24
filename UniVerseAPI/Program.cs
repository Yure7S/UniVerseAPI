using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509.Qualified;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Infra.Data.Repositoryes;
using UniVerseAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region [Config Repository]
    
// Add Repositorys
builder.Services.AddScoped(typeof(IBaseInterface<>), typeof(BaseRepository<>)); // Passing base Repository typo in AddScoped
builder.Services.AddScoped<IStudentInterface, StudentRepository>();

#endregion

#region [Config DbContext]

builder.Services.AddDbContext<UniDBContext>(
        options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

#endregion

builder.Services.AddControllers();
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
