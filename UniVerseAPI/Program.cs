using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509.Qualified;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Infra.Data.Repositoryes;
using UniVerseAPI.Infra.Data.Context;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Application.IServices;
using UniVerseAPI.Application.Services;
using UniVerseAPI.Infra.Data.Repositories;
using System.Text.Json.Serialization;
using System.Text;
using System.Configuration;
using UniVerseAPI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtProperties:key"]);

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); ;

#region [Autentication]

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true, // Valida se contém uma chave
        IssuerSigningKey = new SymmetricSecurityKey(key), // Setando a chave de verificação do token
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

#endregion

#region [Scope]

// CRUD Base
builder.Services.AddScoped(typeof(IBaseInterface<>), typeof(BaseRepository<>));

// Repositories
builder.Services.AddScoped<IStudent, StudentRepository>();
builder.Services.AddScoped<ICourse, CourseRepository>();
builder.Services.AddScoped<ISubject, SubjectRepository>();
builder.Services.AddScoped<IPeople, PeopleRepository>();
builder.Services.AddScoped<ITeacher, TeacherRepository>();
builder.Services.AddScoped<IAddressEntity, AddressEntityRepository>();
builder.Services.AddScoped<IClass, ClassRepository>();
builder.Services.AddScoped<IGrades, GradesRepository>();
builder.Services.AddScoped<IGroupStudentClass, GroupStudentClassRepository>();

// Services
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

#endregion

#region [DbContext]

builder.Services.AddDbContext<UniDBContext>(options =>
{
    options.UseSqlServer("Data Source=localhost;Initial Catalog=UniDB;Persist Security Info=True;User ID=sa;Password=1q2w3e4r@#$;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
});

#endregion

#region Swagger Authentication

// https://dev.to/eduardstefanescu/aspnet-core-swagger-documentation-with-bearer-authentication-40l6
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "UniVerseAPI",
        Description = "API in C# for academic systems, with resources for managing students, courses and professors. The API offers features such as enrollment, enrollment in courses and secure authentication.\r\n\r\n",
    });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
