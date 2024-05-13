using DI.Application.Databases;
using DI.Application.Extensions;
using DI.Application.Repository;
using DI.Domain.Entities;
using DI.Domain.IRepository;
using DI.Services.Extensions;
using DI.Services.ServiceRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile("AppSettings.json",true,true);
IConfiguration configuration = configurationBuilder.Build();



IServiceCollection services = new ServiceCollection();
//services.AddSingleton<IServiceRepository, ServiceRepositoryConcrete>();
services.AddServices();
services.AddAppServices(configuration);

var provider = services.BuildServiceProvider();
var serviceRepository = provider.GetService<IServiceRepository>();

Userx userx = new() { Name = "Sümeyye" };

var usr = serviceRepository.Add(userx);
Console.WriteLine(usr.Name);

usr = serviceRepository.GetByID(1);
Console.WriteLine(usr?.Name);

Console.Read();
