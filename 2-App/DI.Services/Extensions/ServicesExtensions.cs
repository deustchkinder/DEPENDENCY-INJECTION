using DI.Application.Databases;
using DI.Application.Repository;
using DI.Domain.IRepository;
using DI.Services.ServiceRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Services.Extensions;

public static class ServicesExtensions
{
    public static void AddServices (this IServiceCollection services)
    {
        services.AddSingleton<IServiceRepository,ServiceRepositoryConcrete>();
    
    }
}
