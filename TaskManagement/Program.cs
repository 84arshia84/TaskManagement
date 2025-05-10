using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TaskManagement.Application.CommandHandler;
using TaskManagement.Domain;
using TaskManagement.Domain.IRepositories;
using TaskManagement.Host.Configurations;
using TaskManagement.Infrastructure.Repositories;
using TaskManagement.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());




// Configuration
var configuration = builder.Configuration;


builder.Services.AddScoped<ITaskItemRepository,TaskItemRepository>();

// 2. DbContext
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// 3. Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();

builder.Services.AddJwt(builder.Configuration);

// 5. Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireUserOrAdmin", policy => policy.RequireRole("Admin", "User"));
});

// 6. Controllers
builder.Services.AddControllers();



// 8. MediatR
builder.Services.AddMediatR(typeof(RegisterUserCommandHandler).Assembly);

// Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AccountApi", Version = "v1" });

    // Configure Swagger to use JWT Authentication
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your token in the text input below.\n\nExample: 'Bearer 12345abcdef'"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Middleware pipeline
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