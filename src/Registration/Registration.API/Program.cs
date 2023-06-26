using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Registration.Application;
using Registration.Domain.Entities;
using Registration.Domain.Repositories;
using Registration.Infrustraction;
using Registration.Infrustraction.Data;
using Registration.Infrustraction.IdentityValidators;
using Registration.Infrustraction.Repositories;
using FluentValidation;
using static System.Net.Mime.MediaTypeNames;
using MediatR;
using Registration.Application.Behaviors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IPasswordValidator<User>,
    IdenityPasswordValidator>(s => new IdenityPasswordValidator());

builder.Services.AddSingleton<DapperDataContext, SQLiteDapperContext>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsAssembly("Registration.Infrustraction")));
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRegionQueryRepository, RegionQueryRepository>();

var assembly = typeof(MediatorEntryPoint).Assembly;

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssembly(assembly);

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
