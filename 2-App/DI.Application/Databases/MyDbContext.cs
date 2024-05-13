using DI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Application.Databases
{
    public class MyDbContext(DbContextOptions<MyDbContext> ops): DbContext(ops)
    {
        public DbSet<Userx> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         // optionsBuilder.UseSqlServer("server = EMRE; database = DIDB; integrated security = true; TrustServerCertificate = True;");
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}
