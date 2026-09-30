using Microsoft.AspNetCore.Mvc;
using MitraRide.Data;

namespace MitraRide.Controllers;

public class DashboardController : Controller
{
    private readonly MitraRideDbContext _db;
    public DashboardController(MitraRideDbContext db) => _db=db;

    public IActionResult Index()
    {
        if (HttpContext.Session.GetInt32("UserId")==null) return RedirectToAction("Index","Home");
        var role=HttpContext.Session.GetString("Role");
        ViewBag.Role=role;
        ViewBag.Vehicles=role=="Admin"?_db.Vehicles.Count():_db.Vehicles.Count(x=>x.OwnerId==HttpContext.Session.GetInt32("UserId"));
        ViewBag.Documents=role=="Admin"?_db.Documents.Count():_db.Documents.Count(x=>x.OwnerId==HttpContext.Session.GetInt32("UserId"));
        ViewBag.Contacts=role=="Admin"?_db.Contacts.Count():_db.Contacts.Count(x=>x.OwnerId==HttpContext.Session.GetInt32("UserId"));
        ViewBag.Alerts=role=="Admin"?_db.Alerts.Count():_db.Alerts.Count(x=>x.OwnerId==HttpContext.Session.GetInt32("UserId"));
        return View();
    }
}
