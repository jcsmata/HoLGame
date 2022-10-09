using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using HoLGame.API;
using HoLGame.DATA;
using HoLGame.DATA.Infrastructure;
using HoLGame.SERVICES;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HoLGameContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//AUTOFAC
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterType<UnitOfWork<HoLGameContext>>().As<IUnitOfWork<HoLGameContext>>().InstancePerLifetimeScope());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterType<DbFactory<HoLGameContext>>().As<IDbFactory<HoLGameContext>>().InstancePerLifetimeScope());
//builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterType<BLGame>().As<IBLGame>().InstancePerLifetimeScope());

builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterAssemblyTypes(typeof(BLGame).Assembly)
    .Where(t => t.Name.StartsWith("BL"))
    .AsImplementedInterfaces().InstancePerLifetimeScope());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterAssemblyTypes(typeof(SuitRepository).Assembly)
    .Where(t => t.Name.EndsWith("Repository"))
    .AsImplementedInterfaces().InstancePerLifetimeScope());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterAssemblyTypes(typeof(PlayService).Assembly)
    .Where(t => t.Name.EndsWith("Service"))
    .AsImplementedInterfaces().InstancePerLifetimeScope());
//

//AUTOMAPPER
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfile());
});

var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
//


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    //TODO: Adicionar um try catch
    var context = services.GetRequiredService<HoLGameContext>();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
