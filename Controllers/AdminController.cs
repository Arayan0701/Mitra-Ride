using Microsoft.AspNetCore.Mvc;
using MitraRide.Data;

namespace MitraRide.Controllers;
public class AdminController:Controller{
 readonly MitraRideDbContext _db;public AdminController(MitraRideDbContext db)=>_db=db;
 bool OK=>HttpContext.Session.GetString("Role")=="Admin";
 public IActionResult Users(){if(!OK)return Forbid();return View(_db.Users.ToList());}
 [HttpPost]public IActionResult DeleteUser(int id){if(!OK)return Forbid();var u=_db.Users.Find(id);if(u!=null&&u.Role!="Admin"){_db.Users.Remove(u);_db.SaveChanges();}return RedirectToAction("Users");}
}
