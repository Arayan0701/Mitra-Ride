using Microsoft.EntityFrameworkCore;
using MitraRide.Models;

namespace MitraRide.Data;

public class MitraRideDbContext : DbContext
{
    public MitraRideDbContext(DbContextOptions<MitraRideDbContext> options) : base(options) {}
    public DbSet<AppUser> Users => Set<AppUser>();
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<VehicleDocument> Documents => Set<VehicleDocument>();
    public DbSet<EmergencyContact> Contacts => Set<EmergencyContact>();
    public DbSet<Alert> Alerts => Set<Alert>();
    public DbSet<Notification> Notifications => Set<Notification>();
}
