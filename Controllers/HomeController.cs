using Microsoft.AspNetCore.Mvc;

namespace MitraRide.Controllers;
public class HomeController : Controller
{
    public IActionResult Index() => View();
}
