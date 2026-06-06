using Application.CQRS.ProductCommandQuery.Command;
using Application.Interfaces;
using Application.Services;
using Core;
using Core.IRepositories;
using Infrastructure;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Online Store API", Version = "v1" });
    c.EnableAnnotations();
});

#region DI
builder.Services.AddMediatR(typeof(SaveProductCommand));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddRepositories();
builder.Services.AddUnitOfWork();
#endregion

#region DB
string connectionString = builder.Configuration.GetConnectionString("SqlConnection");


builder.Services.AddDbContext<OnlineShopDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});


#endregion


#region AutoMapper
//register AutoMapper
var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new Application.AutoMapperConfig());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion



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
  