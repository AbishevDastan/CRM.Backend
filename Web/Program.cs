using Application.AuthenticationHandlers.HashManager;
using Application.AuthenticationHandlers.JwtManager;
using Application.Extensions;
using Application.Services.AdminService;
using Application.Services.EmployeeService;
using Application.Services.TaskItemService;
using Domain.Abstractions;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Authentication
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("ApplicationSettings:Secret").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

//Authorization
builder.Services.AddAuthorization(options => options.DefaultPolicy =
    new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
    .RequireAuthenticatedUser()
    .Build());

// Repositories
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<ITaskItemRepository, TaskItemRepository>();
builder.Services.AddTransient<IAdminRepository, AdminRepository>();

// Services
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<ITaskItemService, TaskItemService>();
builder.Services.AddTransient<IAdminService, AdminService>();
builder.Services.AddScoped<IJwtManager, JwtManager>();
builder.Services.AddScoped<IHashManager, HashManager>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//CORS
builder.Services.AddCors(options => options.AddPolicy(name: "Mini-CRM",
    policy =>
    {
        policy.WithOrigins("https://localhost:4200", "http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    }));

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter the token:",
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
             },
             new string[] {}
     }
 });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mini-CRM"));
}

app.UseCors("Mini-CRM");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
