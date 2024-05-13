using DI.Application.Databases;
using DI.Application.Repository;
using DI.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Application.Extensions;

public static class AppServicesExtensions
{
    public static void AddAppServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddSingleton<IUserxRepo, UserxRepo>();
        /*
        DbContextOptions<MyDbContext> ops = new DbContextOptionsBuilder<MyDbContext>()
            .UseSqlServer("server = EMRE; database = DIDB; integrated security = true; TrustServerCertificate = True;")
            .Options;
        services.AddSingleton<MyDbContext>(x => new MyDbContext(ops));
        */
        services.AddDbContext<MyDbContext>(x =>
        {
         // x.UseSqlServer("server = EMRE; database = DIDB; integrated security = true; TrustServerCertificate = True;");
            x.UseSqlServer(configuration.GetConnectionString("MyDbContext"));
            x.EnableSensitiveDataLogging();
            x.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        });
    }

}
