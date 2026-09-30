using Microsoft.AspNetCore.Mvc;
using MitraRide.Data;

namespace MitraRide.Controllers;

public class AccountController : Controller
{
    private readonly MitraRideDbContext _db;
    public AccountController(MitraRideDbContext db) => _db = db;

    [HttpGet] public IActionResult Login(string role = "User") { ViewBag.Role = role; return View(); }

    [HttpPost]
    public IActionResult Login(string username, string password, string role)
    {
        var user = _db.Users.FirstOrDefault(x => x.Username == username && x.Password == password && x.Role == role);
        if (user == null) { ViewBag.Role=role; ViewBag.Error="Invalid username, password or role."; return View(); }
        HttpContext.Session.SetInt32("UserId", user.Id);
        HttpContext.Session.SetString("Role", user.Role);
        return RedirectToAction("Index", "Dashboard");
    }

    public IActionResult Logout() { HttpContext.Session.Clear(); return RedirectToAction("Index","Home"); }
}
