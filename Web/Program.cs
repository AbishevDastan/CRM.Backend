using Application.Extensions;
using Application.Services.EmployeeService;
using Application.Services.TaskItemService;
using Domain.Abstractions;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Repositories
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<ITaskItemRepository, TaskItemRepository>();

// Services
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<ITaskItemService, TaskItemService>();

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
