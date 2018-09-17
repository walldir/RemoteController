using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RemoteController.Data.Mappings;
using RemoteController.Domain.Models;

namespace RemoteController.Data.Context
{
    public class RemoteControllerContext : DbContext
    {
        public RemoteControllerContext(DbContextOptions<RemoteControllerContext> options) :base(options) { }

        public DbSet<Machine> Machines { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MachineMap());

            modelBuilder.Entity<Log>()
                .HasOne(l => l.Machine)
                .WithMany(m => m.Logs)
                .IsRequired();

            modelBuilder.Entity<Machine>().HasData(
                new Machine { Id = Guid.NewGuid(), Antivirus = "Norton", DotNetFrameworkVersion = "net461", HdSize = 2000000, IsAvailable = true, IsFirewallActive = true, MacAddress = "8A-71-9B-CA-BB-D7", Name = "Waldir 01", SpaceHdUsed = 100000, IpAddress = "10.0.0.1"},
                new Machine { Id = Guid.NewGuid(), Antivirus = "Avast", DotNetFrameworkVersion = "net461", HdSize = 2000000, IsAvailable = true, IsFirewallActive = true, MacAddress = "8A-71-9B-CA-BB-D4", Name = "Waldir 02", SpaceHdUsed = 100000, IpAddress = "10.0.0.2"},
                new Machine { Id = Guid.NewGuid(), Antivirus = "Avg", DotNetFrameworkVersion = "net461", HdSize = 2000000, IsAvailable = false, IsFirewallActive = true, MacAddress = "8A-71-9B-CA-BB-D5", Name = "Waldir 03", SpaceHdUsed = 100000, IpAddress = "10.0.0.3"}
            );

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
