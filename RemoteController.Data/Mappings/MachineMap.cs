using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RemoteController.Domain.Models;

namespace RemoteController.Data.Mappings
{
    public class MachineMap : IEntityTypeConfiguration<Machine>
    {
        public void Configure(EntityTypeBuilder<Machine> builder)
        {
            builder.Property(m => m.Id)
                .HasColumnName("Id");

            builder.Property(m => m.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(m => m.MacAddress)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(m => m.IpAddress)
                .HasColumnType("varchar(39)")
                .HasMaxLength(39);

            builder.Property(m => m.Antivirus)
                .HasColumnType("varchar(150)")
                .HasMaxLength(150);

            builder.Property(m => m.IsFirewallActive)
                .HasDefaultValue("0")
                .IsRequired();

            builder.Property(m => m.IsAvailiable)
                .HasDefaultValue("0")
                .IsRequired();

            builder.Property(m => m.WindowsVersion)
                .HasColumnType("varchar(150)")
                .HasMaxLength(150);

            builder.Property(m => m.DotNetFrameworkVersion)
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);

            builder.Property(m => m.SpaceHdUsed);

            builder.Property(m => m.HdSize);
        }
    }
}
