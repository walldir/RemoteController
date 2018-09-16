using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RemoteController.Data.Mappings;
using RemoteController.Domain.Models;

namespace RemoteController.Data.Context
{
    public class RemoteControllerContext : DbContext
    {
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MachineMap());

            modelBuilder.Entity<Log>()
                .HasOne(l => l.Machine)
                .WithMany(m => m.Logs)
                .IsRequired();

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
