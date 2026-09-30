using Microsoft.AspNetCore.Mvc;
using MitraRide.Data;
using MitraRide.Models;

namespace MitraRide.Controllers;
public class ContactsController:Controller{
 readonly MitraRideDbContext _db;public ContactsController(MitraRideDbContext db)=>_db=db;int? UID=>HttpContext.Session.GetInt32("UserId");bool Admin=>HttpContext.Session.GetString("Role")=="Admin";
 public IActionResult Index(){if(UID==null)return RedirectToAction("Index","Home");return View(Admin?_db.Contacts.ToList():_db.Contacts.Where(x=>x.OwnerId==UID).ToList());}
 [HttpPost]public IActionResult Create(EmergencyContact c){if(UID==null)return RedirectToAction("Index","Home");c.OwnerId=UID.Value;_db.Contacts.Add(c);_db.SaveChanges();return RedirectToAction("Index");}
 [HttpPost]public IActionResult Delete(int id){if(!Admin)return Forbid();var c=_db.Contacts.Find(id);if(c!=null){_db.Contacts.Remove(c);_db.SaveChanges();}return RedirectToAction("Index");}
}
