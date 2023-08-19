using Application.Commands;
using Application.Handlers;
using Application.Interfaces;
using Application.Models;
using Application.Profiles;
using Application.Queries;
using Application.Requests;
using Application.Responses;
using Application.Services;
using Application.Validators;
using Domain.Entities;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net.NetworkInformation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
//Register Configuration
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped<IRequestHandler<UserAddCommand, Unit>, UserAddCommandHandler>();
builder.Services.AddScoped<IRequestHandler<UserGetAllQuery, List<UserGetAllViewModel>>, UserGetAllQueryHandler>();
builder.Services.AddScoped<IRequestHandler<UserGetByIdQuery, UserGetByIdViewModel>, UserGetByIdQueryHandler>();

builder.Services.AddScoped<IRequestHandler<UserModifyCommand, UserModifyViewModel>, UserModifyCommandHandler>();
builder.Services.AddScoped<IRequestHandler<UserDeleteCommand>, UserDeleteCommandHandler>();

builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("APISimpleCSDevelopment"), 
    b=> b.MigrationsAssembly("APISimple")));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddValidatorsFromAssemblyContaining<UserAddValidator>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
