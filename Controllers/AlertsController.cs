using Microsoft.AspNetCore.Mvc;
using MitraRide.Data;
using MitraRide.Models;

namespace MitraRide.Controllers;
public class AlertsController:Controller{
 readonly MitraRideDbContext _db;public AlertsController(MitraRideDbContext db)=>_db=db;int? UID=>HttpContext.Session.GetInt32("UserId");bool Admin=>HttpContext.Session.GetString("Role")=="Admin";
 public IActionResult Index(){if(UID==null)return RedirectToAction("Index","Home");return View(Admin?_db.Alerts.OrderByDescending(x=>x.CreatedAt).ToList():_db.Alerts.Where(x=>x.OwnerId==UID).OrderByDescending(x=>x.CreatedAt).ToList());}
 [HttpPost]public IActionResult Create(string type,string vehicle,string message){if(UID==null)return RedirectToAction("Index","Home");_db.Alerts.Add(new Alert{Type=type,Vehicle=vehicle,Message=message,OwnerId=UID.Value});_db.SaveChanges();_db.Notifications.Add(new Notification{OwnerId=UID.Value,Title=type+" created",Message="Your alert has been recorded."});_db.SaveChanges();return RedirectToAction("Index");}
 [HttpPost]public IActionResult Delete(int id){if(!Admin)return Forbid();var a=_db.Alerts.Find(id);if(a!=null){_db.Alerts.Remove(a);_db.SaveChanges();}return RedirectToAction("Index");}
}
