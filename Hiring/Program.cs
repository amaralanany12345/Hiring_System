using Hiring.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.IdentityModel.Tokens;
using Hiring.Models;
using System.Text;
using Hiring.Services;
using Hiring;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddSignalR();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddMemoryCache();

// Configure Kestrel and Form options for large request sizes
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.MaxRequestBodySize = 104857600; 
});
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 104857600; 
});

builder.Services.AddControllers().AddNewtonsoftJson(x =>
    x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// CORS policy for your Angular app
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Register services for dependency injection
builder.Services.AddSingleton<EmployeeService>();
builder.Services.AddSingleton<SigningService>();
builder.Services.AddSingleton<CompanyService>();
builder.Services.AddSingleton<AppDbContext>();
builder.Services.AddSingleton<ExperienceService>();
builder.Services.AddSingleton<EducationService>();
builder.Services.AddSingleton<SkillService>();
builder.Services.AddSingleton<VacancyService>();
builder.Services.AddSingleton<EmployeeVacancyService>();
builder.Services.AddSingleton<CvService>();



// JWT Authentication setup
var JwtOptions = builder.Configuration.GetSection("Jwt").Get<Jwt>();
builder.Services.AddSingleton(JwtOptions);
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = JwtOptions.Issuer,
        ValidateAudience = true,
        ValidAudience = JwtOptions.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOptions.SigningKey)),
    };
});

// Add Swagger support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the app
var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();
app.UseAuthorization();

// Map controllers
app.MapControllers();

app.Run();
