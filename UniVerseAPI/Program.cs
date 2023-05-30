using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509.Qualified;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Infra.Data.Repositoryes;
using UniVerseAPI.Infra.Data.Context;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Application.IServices;
using UniVerseAPI.Application.Services;
using UniVerseAPI.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region [Config Repository]
    
// CRUD Base
builder.Services.AddScoped(typeof(IBaseInterface<>), typeof(BaseRepository<>));

// Repositories
builder.Services.AddScoped<IStudent, StudentRepository>();
builder.Services.AddScoped<ICourse, CourseRepository>();
builder.Services.AddScoped<IPeople, PeopleRepository>();
builder.Services.AddScoped<IAddressEntity, AddressEntityRepository>();

// Services
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IStudentService, StudentService>();

#endregion

#region [Config DbContext]

builder.Services.AddDbContext<UniDBContext>(options =>
{
    options.UseSqlServer("Data Source=localhost;Initial Catalog=UniDB;Persist Security Info=True;User ID=sa;Password=1q2w3e4r@#$;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
});

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
