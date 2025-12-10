using Microsoft.EntityFrameworkCore;
using ssi730ebu202319415.API.Inventory.Domain.Model.Aggregates;
using ssi730ebu202319415.API.Observability.Domain.Model.Aggregates;
using ssi730ebu202319415.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace ssi730ebu202319415.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Inventory
        builder.Entity<Thing>().ToTable("things");
        builder.Entity<Thing>().HasKey(t => t.Id);
        builder.Entity<Thing>().Property(t => t.Id).ValueGeneratedOnAdd();
        builder.Entity<Thing>().OwnsOne(t => t.SerialNumber, sn =>
        {
            sn.WithOwner();
            sn.Property(p => p.Value).HasColumnName("serial_number");
        });
        builder.Entity<Thing>().Property(t => t.Model);
        builder.Entity<Thing>().Property(t => t.OperationMode).HasConversion<int>();
        builder.Entity<Thing>().Property(t => t.MaximumTemperatureThreshold).HasPrecision(5,2);
        builder.Entity<Thing>().Property(t => t.MinimumHumidityThreshold).HasPrecision(5,2);

        // Observability
        builder.Entity<ThingState>().ToTable("thing_states");
        builder.Entity<ThingState>().HasKey(ts => ts.Id);
        builder.Entity<ThingState>().Property(ts => ts.Id).ValueGeneratedOnAdd();
        builder.Entity<ThingState>().OwnsOne(ts => ts.ThingSerialNumber, sn =>
        {
            sn.WithOwner();
            sn.Property(p => p.Value).HasColumnName("thing_serial_number");
        });
        builder.Entity<ThingState>().Property(ts => ts.CurrentOperationMode);
        builder.Entity<ThingState>().Property(ts => ts.CurrentTemperature).HasPrecision(5,2);
        builder.Entity<ThingState>().Property(ts => ts.CurrentHumidity).HasPrecision(5,2);
        builder.Entity<ThingState>().Property(ts => ts.CollectedAt);

        //builder.UseSnakeCaseNamingConvention();
    }
}