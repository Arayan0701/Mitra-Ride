using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MitraRide.Data;
using MitraRide.Models;

namespace MitraRide.Controllers;

public class VehiclesController : Controller
{
    private readonly MitraRideDbContext _db;
    public VehiclesController(MitraRideDbContext db)=>_db=db;
    int? UID=>HttpContext.Session.GetInt32("UserId");
    bool Admin=>HttpContext.Session.GetString("Role")=="Admin";
    public IActionResult Index(){ if(UID==null)return RedirectToAction("Index","Home"); var v=Admin?_db.Vehicles.ToList():_db.Vehicles.Where(x=>x.OwnerId==UID).ToList(); return View(v); }
    [HttpPost] public IActionResult Create(Vehicle v){if(UID==null)return RedirectToAction("Index","Home");v.OwnerId=UID.Value;_db.Vehicles.Add(v);_db.SaveChanges();return RedirectToAction("Index");}
    [HttpPost] public IActionResult Delete(int id){if(!Admin)return Forbid();var v=_db.Vehicles.Find(id);if(v!=null){_db.Vehicles.Remove(v);_db.SaveChanges();}return RedirectToAction("Index");}
}
