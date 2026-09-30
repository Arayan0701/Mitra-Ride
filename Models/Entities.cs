namespace MitraRide.Models;

public class AppUser
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string Email { get; set; } = "";
    public string Role { get; set; } = "User";
}

public class Vehicle
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Plate { get; set; } = "";
    public string Make { get; set; } = "";
    public string Model { get; set; } = "";
    public string Status { get; set; } = "Active";
    public int OwnerId { get; set; }
}

public class VehicleDocument
{
    public int Id { get; set; }
    public string VehiclePlate { get; set; } = "";
    public string Type { get; set; } = "";
    public DateTime Expiry { get; set; }
    public string Status { get; set; } = "Valid";
    public int OwnerId { get; set; }
}

public class EmergencyContact
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Relation { get; set; } = "";
    public string Phone { get; set; } = "";
    public int OwnerId { get; set; }
}

public class Alert
{
    public int Id { get; set; }
    public string Type { get; set; } = "";
    public string Vehicle { get; set; } = "";
    public string Message { get; set; } = "";
    public string Status { get; set; } = "Created";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int OwnerId { get; set; }
}

public class Notification
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Message { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int OwnerId { get; set; }
    public bool IsRead { get; set; }
}
