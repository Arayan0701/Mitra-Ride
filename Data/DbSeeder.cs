using MitraRide.Models;

namespace MitraRide.Data;

public static class DbSeeder
{
    public static void Seed(MitraRideDbContext db)
    {
        if (db.Users.Any()) return;

        db.Users.AddRange(
            new AppUser { Name="Arayan Savaliya", Username="user", Password="user123", Email="user@mitraride.local", Role="User" },
            new AppUser { Name="System Administrator", Username="admin", Password="admin123", Email="admin@mitraride.local", Role="Admin" }
        );
        db.SaveChanges();

        var user = db.Users.First(x => x.Username == "user");
        db.Vehicles.Add(new Vehicle { Name="Daily Car", Plate="GJ 03 AB 1234", Make="Hyundai", Model="i20", OwnerId=user.Id });
        db.Documents.AddRange(
            new VehicleDocument { VehiclePlate="GJ 03 AB 1234", Type="Driving Licence", Expiry=new DateTime(2027,5,12), OwnerId=user.Id },
            new VehicleDocument { VehiclePlate="GJ 03 AB 1234", Type="Registration Certificate", Expiry=new DateTime(2028,1,18), OwnerId=user.Id },
            new VehicleDocument { VehiclePlate="GJ 03 AB 1234", Type="Insurance", Expiry=new DateTime(2026,12,21), OwnerId=user.Id }
        );
        db.Contacts.Add(new EmergencyContact { Name="Family Contact", Relation="Family", Phone="+91 98765 43210", OwnerId=user.Id });
        db.SaveChanges();
    }
}
