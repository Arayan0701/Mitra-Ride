using Microsoft.AspNetCore.Mvc;
using MitraRide.Data;
using MitraRide.Models;

namespace MitraRide.Controllers;
public class DocumentsController:Controller{
 readonly MitraRideDbContext _db; public DocumentsController(MitraRideDbContext db)=>_db=db;
 int? UID=>HttpContext.Session.GetInt32("UserId"); bool Admin=>HttpContext.Session.GetString("Role")=="Admin";
 public IActionResult Index(){if(UID==null)return RedirectToAction("Index","Home");return View(Admin?_db.Documents.ToList():_db.Documents.Where(x=>x.OwnerId==UID).ToList());}
 [HttpPost]public IActionResult Create(VehicleDocument d){if(UID==null)return RedirectToAction("Index","Home");d.OwnerId=UID.Value;_db.Documents.Add(d);_db.SaveChanges();return RedirectToAction("Index");}
 [HttpPost]public IActionResult Delete(int id){if(!Admin)return Forbid();var d=_db.Documents.Find(id);if(d!=null){_db.Documents.Remove(d);_db.SaveChanges();}return RedirectToAction("Index");}
}
